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
    public class RealEstateTypeService : IRealEstateTypeService
    {
        IRepository<RealEstateType, int> repository;
        IServiceT<RealEstateType, RealEstateTypeDTO, int> service;
        public RealEstateTypeService(IRepository<RealEstateType, int> repository,
                                         IServiceT<RealEstateType, RealEstateTypeDTO, int> service)
        {
            this.repository = repository;
            this.service = service;
        }

        public async Task<List<RealEstateTypeDTO>> GetAllRealEstateTypesAsync(Expression<Func<RealEstateTypeDTO, bool>> where = null)
        {
            return await service.GetAllItemsAsync(where);
        }

        public async Task<RealEstateTypeDTO> GetRealEstateTypeByIdAsync(int id)
        {
            return await service.GetItemByIdAsync(id);
        }

        public async Task<RealEstateTypeDTO> GetRealEstateTypeByParamsAsync(Expression<Func<RealEstateTypeDTO, bool>> where)
        {
            return await service.GetItemByParamsAsync(where);
        }

        public async Task<OperationDetails> CreateRealEstateTypeAsync(RealEstateTypeDTO realEstateTypeDto, OperationDetails MessageSuccess, OperationDetails MessageFail)
        {
            return (await service.CreateItemAsync(realEstateTypeDto,
                new RealEstateTypeEquelSpecification(realEstateTypeDto).ToExpression(),
                MessageSuccess,
                MessageFail)).Item1;
        }

        public async Task<OperationDetails> DeleteRealEstateTypeAsync(int id, OperationDetails MessageSuccess, OperationDetails MessageFail)
        {
            return await service.DeleteItemAsync(id,
                MessageSuccess,
                MessageFail);
        }

        public async Task<OperationDetails> UpdateRealEstateTypeAsync(RealEstateTypeDTO realEstateTypeDto, OperationDetails MessageSuccess, OperationDetails MessageFail)
        {
            int idTypeDto = realEstateTypeDto.RealEstateTypeID;
            return await service.UpdateItemAsync(realEstateTypeDto,
                idTypeDto,
                MessageSuccess,
                MessageFail);
        }
        public void Dispose()
        {
            repository.Dispose();
        }

        public async Task<List<RealEstateTypeDTO>> FilterRealEstateTypeAsync(RealEstateTypeFilterModel realEstateTypeFilter)
        {
            List<RealEstateTypeDTO> list = await this.GetAllRealEstateTypesAsync();
            if (realEstateTypeFilter.RealEstateTypeID != null) list = list.Where(emp => emp.RealEstateTypeID == realEstateTypeFilter.RealEstateTypeID).ToList();
            if (realEstateTypeFilter.RealEstateTypeName != null) list = list.Where(emp => emp.RealEstateTypeName == realEstateTypeFilter.RealEstateTypeName).ToList();
            return list;
        }
    }
}
