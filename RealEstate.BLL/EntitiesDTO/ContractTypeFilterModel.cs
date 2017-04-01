using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Attributes;
using FluentValidation;

namespace RealEstateAgency.BLL.EntitiesDTO
{
    public class ContractTypeFilterModel
    {
        public int? ContractTypeID { get; set; }
        public string ContractTypeName { get; set; }
    }
}
