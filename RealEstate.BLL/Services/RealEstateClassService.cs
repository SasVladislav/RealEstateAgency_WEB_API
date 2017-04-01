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
    public class RealEstateClassService : IRealEstateClassService
    {
        IRepository<RealEstateClass, int> repository;
        IServiceT<RealEstateClass, RealEstateClassDTO, int> service;
        public RealEstateClassService(IRepository<RealEstateClass, int> repository,
                                         IServiceT<RealEstateClass, RealEstateClassDTO, int> service)
        {
            this.repository = repository;
            this.service = service;
        }

        public async Task<List<RealEstateClassDTO>> GetAllRealEstateClassesAsync(Expression<Func<RealEstateClassDTO, bool>> where = null)
        {
            return await service.GetAllItemsAsync(where);
        }

        public async Task<RealEstateClassDTO> GetRealEstateClassByIdAsync(int id)
        {
            return await service.GetItemByIdAsync(id);
        }

        public async Task<RealEstateClassDTO> GetRealEstateClassByParamsAsync(Expression<Func<RealEstateClassDTO, bool>> where)
        {
            return await service.GetItemByParamsAsync(where);
        }

        public async Task<OperationDetails> CreateRealEstateClassAsync(RealEstateClassDTO realEstateClassDto, OperationDetails MessageSuccess, OperationDetails MessageFail)
        {
            return (await service.CreateItemAsync(realEstateClassDto,
                new RealEstateClassEquelSpecification(realEstateClassDto).ToExpression(),
                MessageSuccess,
                MessageFail)).Item1;
        }

        public async Task<OperationDetails> DeleteRealEstateClassAsync(int id, OperationDetails MessageSuccess, OperationDetails MessageFail)
        {
            return await service.DeleteItemAsync(id,
                MessageSuccess,
                MessageFail);
        }

        public async Task<OperationDetails> UpdateRealEstateClassAsync(RealEstateClassDTO realEstateClassDto, OperationDetails MessageSuccess, OperationDetails MessageFail)
        {
            int idClassDto = realEstateClassDto.RealEstateClassID;
            return await service.UpdateItemAsync(realEstateClassDto,
                idClassDto,
                MessageSuccess,
                MessageFail);           
        }
        public void Dispose()
        {
            repository.Dispose();
        }

        public async Task<List<RealEstateClassDTO>> FilterRealEstateClassAsync(RealEstateClassFilterModel realEstateClassFilter)
        {
            List<RealEstateClassDTO> list = await this.GetAllRealEstateClassesAsync();
            if (realEstateClassFilter.RealEstateClassID != null) list = list.Where(emp => emp.RealEstateClassID == realEstateClassFilter.RealEstateClassID).ToList();
            if (realEstateClassFilter.RealEstateClassName != null) list = list.Where(emp => emp.RealEstateClassName == realEstateClassFilter.RealEstateClassName).ToList();
            return list;
        }
    }
}
