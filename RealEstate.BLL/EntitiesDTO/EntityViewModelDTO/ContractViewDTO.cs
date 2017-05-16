using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgency.BLL.EntitiesDTO.EntityViewModelDTO
{
    public class ContractViewDTO
    {
        public ContractViewDTO()
        {
            Contract = new ContractDTO();
            UserView = new UserViewDTO();
            RealEstateView = new RealEstateViewDTO();
            Employee = new EmployeeDTO();
        }

        public ContractDTO Contract { get; set; }
        public UserViewDTO UserView { get; set; }
        public RealEstateViewDTO RealEstateView { get; set; }
        public EmployeeDTO Employee { get; set; }
    }
}
