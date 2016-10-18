using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinookSystem.Security
{
    public enum UnregisteredUserType { Undefined, Employee, Customer}
    public class UnregisteredUserProfile
    {
        public string UserId { get; set; }      //Generated
        public string UserName { get; set; }    //Collected
        public string EmailAddress { get; set; }//Collected
        public int? EmployeeId { get; set; }
        public int? CustomerId { get; set; }
        public string FirstName { get; set; }   //comes from user table
        public string LastName { get; set; }    //comes from user table
        public UnregisteredUserType UserType { get; set; }


    }
}
