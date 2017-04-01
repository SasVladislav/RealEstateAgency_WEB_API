using RealEstateAgency.BLL.Infrastuctures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgency.BLL.Interfaces
{
    public abstract class SpecificationMessage
    {
        public abstract OperationDetails ToSuccessCreateMessage();
        public abstract OperationDetails ToSuccessDeleteMessage();
        public abstract OperationDetails ToSuccessUpdateMessage();
        public abstract OperationDetails ToFailCreateMessage();
        public abstract OperationDetails ToFailDeleteMessage();
        public abstract OperationDetails ToFailUpdateMessage();
    }
}
