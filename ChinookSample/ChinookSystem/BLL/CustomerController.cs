using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region AdditionalNamspaces
using System.ComponentModel;
using ChinookSystem.Data.Entities;
using ChinookSystem.Data.POCOs;
using ChinookSystem.DAL;
#endregion

namespace ChinookSystem.BLL
{
    [DataObject]
    public class CustomerController
    {
        public List<RepresentativeCustomers> RepresentativeCustomers_Get()
        {
            using (var context = new ChinookContext())
            {
                var results = from x in context.Customers where x.Employee.FirstName.Equals("Jane") && x.Employee.LastName.Equals("Peacock") orderby x.LastName, x.FirstName select new RepresentativeCustomers { Name = x.LastName, City = x.City, State = x.State, Phone = x.Phone, Email = x.Email };
                return results.ToList();
            }
        }
    }
}
