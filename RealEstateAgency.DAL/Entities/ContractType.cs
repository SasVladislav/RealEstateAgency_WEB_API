using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgency.DAL.Entities
{
    public class ContractType
    {
        public int ContractTypeID { get; set; }
        public string ContractTypeName { get; set; }
        public virtual ICollection<Contract> Contracts { get; set; }
    }
}
