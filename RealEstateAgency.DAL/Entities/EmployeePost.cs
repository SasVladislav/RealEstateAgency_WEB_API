using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgency.DAL.Entities
{
    public class EmployeePost
    {
        public int EmployeePostID { get; set; }
        public string EmployeePostName { get; set; }
        public double? EmployeePostSalary { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
