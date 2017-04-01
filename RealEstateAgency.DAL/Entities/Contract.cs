using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgency.DAL.Entities
{
    public class Contract
    {
        public int ContractID { get; set; }
        public int RealEstateID { get; set; }
        public string BuyerID { get; set; }
        public string SellerID{ get; set; }
        public string EmployeeID { get; set; }
        public int ContractTypeID { get; set; }
        public string RecordDate { get; set; }
        public virtual RealEstate RealEstate { get; set; }
        public virtual Person Buyer { get; set; }
        public virtual Person Seller { get; set; }
        public virtual Person Employee { get; set; }
        public virtual ContractType ContractType { get; set; }
        
    }
}
