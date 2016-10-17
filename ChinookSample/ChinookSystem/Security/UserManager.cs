using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region additional namespaces
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
#endregion

namespace ChinookSystem.Security
{
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
        }
        


    }//eoc

}//eon
