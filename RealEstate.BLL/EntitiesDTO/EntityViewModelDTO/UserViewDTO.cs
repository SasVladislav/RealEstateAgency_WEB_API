using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgency.BLL.EntitiesDTO.EntityViewModelDTO
{
    public class UserViewDTO : AbstractPersonViewModel<UserDTO>
    {
        public UserViewDTO()
        {
            Person = new UserDTO();
            Address = new AddressDTO();
        }

    }
}
