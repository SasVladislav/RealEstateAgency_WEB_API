using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstateAgency.DAL.Interfaces;
using RealEstateAgency.DAL.Entities;
using RealEstateAgency.DAL.Repositories;
using RealEstateAgency.DAL.EF;
using RealEstateAgency.BLL.Infrastuctures;
using RealEstateAgency.BLL.EntitiesDTO;
using RealEstateAgency.BLL.Interfaces;
using RealEstateAgency.BLL.Service;
using System.Linq.Expressions;
using RealEstateAgency.BLL.Specifications;

namespace RealEstateAgency.BLL.Services
{
    public class RealEstateTypeWallService : IRealEstateTypeWallService
    {
        IRepository<RealEstateTypeWall, int> repository;
        IServiceT<RealEstateTypeWall, RealEstateTypeWallDTO, int> service;
        public RealEstateTypeWallService(IRepository<RealEstateTypeWall, int> repository,
                                         IServiceT<RealEstateTypeWall, RealEstateTypeWallDTO, int> service)
        {
            this.repository = repository;
            this.service = service;
        }

        public async Task<List<RealEstateTypeWallDTO>> GetAllRealEstateTypeWallsAsync(Expression<Func<RealEstateTypeWallDTO, bool>> where = null)
        {           
                return await service.GetAllItemsAsync(where);          
        }

        public async Task<RealEstateTypeWallDTO> GetRealEstateTypeWallByIdAsync(int id)
        {
            return await service.GetItemByIdAsync(id);
        }

        public async Task<RealEstateTypeWallDTO> GetRealEstateTypeWallByParamsAsync(Expression<Func<RealEstateTypeWallDTO, bool>> where)
        {
            return await service.GetItemByParamsAsync(where);
        }
        public async Task<OperationDetails> CreateRealEstateTypeWallAsync(RealEstateTypeWallDTO realEstateTypeWallDto, OperationDetails MessageSuccess, OperationDetails MessageFail)
        {
        return (await service.CreateItemAsync(realEstateTypeWallDto,
                new RealEstateTypeWallEquelSpecification(realEstateTypeWallDto).ToExpression(),
                MessageSuccess,
                MessageFail)).Item1;           
        }

        public async Task<OperationDetails> DeleteRealEstateTypeWallAsync(int id, OperationDetails MessageSuccess, OperationDetails MessageFail)
        {
        return await service.DeleteItemAsync(id,
                MessageSuccess,
                MessageFail);
        }

        public async Task<OperationDetails> UpdateRealEstateTypeWallAsync(RealEstateTypeWallDTO realEstateTypeWallDto, OperationDetails MessageSuccess, OperationDetails MessageFail)
        {
            int idTypeWallDto = realEstateTypeWallDto.RealEstateTypeWallID;
        return await service.UpdateItemAsync(realEstateTypeWallDto,
                idTypeWallDto,
                MessageSuccess,
                MessageFail);
        }
        public void Dispose()
        {
            repository.Dispose();
        }

        public async Task<List<RealEstateTypeWallDTO>> FilterRealEstateTypeWallAsync(RealEstateTypeWallFilterModel realEstateTypeWallFilter)
        {
            List<RealEstateTypeWallDTO> list = await this.GetAllRealEstateTypeWallsAsync();
            if (realEstateTypeWallFilter.RealEstateTypeWallID != null) list = list.Where(emp => emp.RealEstateTypeWallID == realEstateTypeWallFilter.RealEstateTypeWallID).ToList();
            if (realEstateTypeWallFilter.RealEstateTypeWallName != null) list = list.Where(emp => emp.RealEstateTypeWallName == realEstateTypeWallFilter.RealEstateTypeWallName).ToList();
            return list;
        }
    }
}
