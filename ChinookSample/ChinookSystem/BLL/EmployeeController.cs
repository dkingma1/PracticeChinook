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
    public class EmployeeController
    {
        public List<EmployeeNameList> EmployeeNameList_Get()
        {
            using (var context = new ChinookContext())
            {
                var results = from x in context.Employees orderby x.LastName, x.FirstName select new EmployeeNameList { EmployeeId = x.EmployeeId, Name = x.LastName + ", " + x.FirstName };
                return results.ToList();
            }
        }
    }
}
