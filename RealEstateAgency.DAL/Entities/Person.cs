using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateAgency.DAL.Entities
{
    public abstract class Person
    {
        public string PersonId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronumic { get; set; }
        public int PhoneNumber { get; set; }
        public string PassportNumber { get; set; }
        public int AddressID { get; set; }
        public virtual Address Address { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
