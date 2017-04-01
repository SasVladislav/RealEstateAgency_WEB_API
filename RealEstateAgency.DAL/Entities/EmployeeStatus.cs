using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgency.DAL.Entities
{
    public class EmployeeStatus
    {
        public int EmployeeStatusID { get; set; }
        public string EmployeeStatusName { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
