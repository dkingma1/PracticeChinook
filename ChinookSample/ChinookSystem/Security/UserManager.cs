using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region additional namespaces
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System.ComponentModel;
using ChinookSystem.DAL;
#endregion

namespace ChinookSystem.Security
{
    [DataObject]
    public class UserManager : UserManager<ApplicationUser>
    {
        public UserManager()
            : base(new UserStore<ApplicationUser>(new ApplicationDbContext()))
        {
        }

        //setting up the default webMaster
        #region Constants
        private const string STR_DEFAULT_PASSWORD = "Pa$$word1";
        private const string STR_USERNAME_FORMAT = "{0}.{1}";
        private const string STR_EMAIL_FORMAT = "{0}@Chinook.ca";
        private const string STR_WEBMASTER_USERNAME = "Webmaster";
        #endregion

        public void AddWebmaster()
        {
            if (!Users.Any(u => u.UserName.Equals(STR_WEBMASTER_USERNAME)))
            {
                var webMasterAccount = new ApplicationUser()
                {
                    UserName = STR_WEBMASTER_USERNAME,
                    Email = string.Format(STR_EMAIL_FORMAT, STR_WEBMASTER_USERNAME)
                };
                //This create command is from the inherated UserManager class.
                //This command creates a record on the security Users table (AspNetUsers)
                this.Create(webMasterAccount, STR_DEFAULT_PASSWORD);

                //This add to role command is from the inherited UserManager class.
                //This command creates created a record on the security on the UserRole table (AspNetUserRoles)
                this.AddToRole(webMasterAccount.Id, SecurityRoles.WebsiteAdmins);

            }
        }//eom

        //Create the crud methods for adding a user to the security User table. 
        //Read of data to display on gridview
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<UnregisteredUserProfile> ListAllUnregisteredUsers()
        {
            using (var context = new ChinookContext())
            {
                //The data needs to be in memory for execution by the next query. To acomplish this use .ToList() which will force the query to execute.
                //List set conatining the list of employeeId's
                var registeredEmployees = (from emp in Users where emp.EmployeeId.HasValue select emp.EmployeeId).ToList();
                //Comapre the IEnumerable set to the user datatable employees
                var unregisteredEmployees = (from emp in context.Employees
                                            where !registeredEmployees.Any(eid => emp.EmployeeId == eid)
                                            select new UnregisteredUserProfile()
                                            {
                                                UserId = emp.EmployeeId,
                                                FirstName = emp.FirstName,
                                                LastName = emp.LastName,
                                                UserType = UnregisteredUserType.Employee
                                            }).ToList();

                //List set conatining the list of customerId's
                var registeredCustomers = (from cust in Users where cust.CustomerId.HasValue select cust.EmployeeId).ToList();
                //Comapre the IEnumerable set to the user datatable employees
                var unregisteredCustomers = (from cust in context.Customers
                                            where !registeredCustomers.Any(cid => cust.CustomerId == cid)
                                            select new UnregisteredUserProfile()
                                            {
                                                UserId = cust.CustomerId,
                                                FirstName = cust.FirstName,
                                                LastName = cust.LastName,
                                                UserType = UnregisteredUserType.Customer
                                            }).ToList();
                //Combine the 2 physically identical layout datasets 
                return unregisteredEmployees.Union(unregisteredCustomers).ToList();
            }

        }
        //Register a User to the User table (GridView)
        public void RegisterUser(UnregisteredUserProfile userinfo)
        {
            //The basic information needed for the security user record: Password, Email, Username. You could randomly generate a password, we will use the default password. The instance of the required user is based on our ApplicationUser. 
            var newuseraccount = new ApplicationUser()
            {
                UserName = userinfo.UserName,
                Email = userinfo.EmailAddress
            };
            //Set the customerId or the employeeId
            switch (userinfo.UserType)
            {
                case UnregisteredUserType.Customer:
                    {
                        newuseraccount.Id = userinfo.UserId.ToString();
                        break;
                    }
                case UnregisteredUserType.Employee:
                    {
                        newuseraccount.Id = userinfo.UserId.ToString();
                        break;
                    }
            }
            //Create the actual AspNetUser record
            this.Create(newuseraccount, STR_DEFAULT_PASSWORD);

            //Assign user to an appropriate role.
            switch (userinfo.UserType)
            {
                case UnregisteredUserType.Customer:
                    {
                        this.AddToRole(newuseraccount.Id, SecurityRoles.RegisteredUsers);
                        break;
                    }
                case UnregisteredUserType.Employee:
                    {
                        this.AddToRole(newuseraccount.Id, SecurityRoles.Staff);
                        break;
                    }
            }
        }
        //Add a User to the User table (ListView)

        //Delete a user from the User table (ListView)


    }//eoc

}//eon
