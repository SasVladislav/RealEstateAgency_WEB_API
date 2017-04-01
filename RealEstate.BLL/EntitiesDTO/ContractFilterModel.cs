using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Attributes;
using FluentValidation;

namespace RealEstateAgency.BLL.EntitiesDTO
{
    public class ContractFilterModel
    {
        public int? ContractID { get; set; }
        public int? RealEstateID { get; set; }
        public string BuyerID { get; set; }
        public string SellerID { get; set; }
        public string EmployeeID { get; set; }
        public int? ContractTypeID { get; set; }
        public string RecordDate { get; set; }
    }
}
