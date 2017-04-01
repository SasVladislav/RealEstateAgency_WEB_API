using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace RealEstateAgency.DAL.Entities
{
    public class Employee : Person
    {
        public int EmployeePostID { get; set; }
        public int EmployeeStatusID { get; set; }
        public bool StateOnline { get; set; }
        //public int AddressID { get; set; }
        public virtual EmployeePost EmployeePost { get; set; }
        public virtual EmployeeStatus EmployeeStatus { get; set; }
        public virtual ICollection<EmployeeDismiss> EmployeeDismisses { get; set; }
        //public virtual Address Address { get; set; }
        //public virtual ICollection<Contract> Contracts { get; set; }
    }
}
