using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgency.BLL.EntitiesDTO.EntityViewModelDTO
{
    public class EmployeeViewDTO : AbstractPersonViewModel<EmployeeDTO>
    {
        public EmployeeViewDTO()
        {
            Person = new EmployeeDTO();
            Address = new AddressDTO();
            Dismisses = new List<EmployeeDismissDTO>();
        }
        public List<EmployeeDismissDTO> Dismisses { get; set; }
    }
}
