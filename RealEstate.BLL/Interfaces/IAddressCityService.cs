using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstateAgency.BLL.EntitiesDTO;
using RealEstateAgency.BLL.Infrastuctures;
using System.Linq.Expressions;
using RealEstateAgency.DAL.Entities;

namespace RealEstateAgency.BLL.Interfaces
{
   public interface IAddressCityService: IDisposable
    {
        Task<List<AddressCityDTO>> GetAllAddressCitiesAsync(Expression<Func<AddressCityDTO, bool>> where = null);
        Task<AddressCityDTO> GetAddressCityByIdAsync(int id);
        Task<AddressCityDTO> GetAddressCityByParamsAsync(Expression<Func<AddressCityDTO, bool>> where);
        Task<OperationDetails> CreateAddressCityAsync(AddressCityDTO addressCityDto,OperationDetails MessageSuccess, OperationDetails MessageFail);
        Task<OperationDetails> DeleteAddressCityAsync(int id, OperationDetails MessageSuccess, OperationDetails MessageFail);
        Task<OperationDetails> UpdateAddressCityAsync(AddressCityDTO addressCityDto, OperationDetails MessageSuccess, OperationDetails MessageFail);
        Task<List<AddressCityDTO>> FilterAddressCityAsync(AddressCityFilterModel addressCityFilter);
    }
}
