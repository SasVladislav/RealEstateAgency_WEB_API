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
    public class RealEstateStatusService : IRealEstateStatusService
    {
        IRepository<RealEstateStatus, int> repository;
        IServiceT<RealEstateStatus, RealEstateStatusDTO, int> service;
        public RealEstateStatusService(IRepository<RealEstateStatus, int> repository,
                                         IServiceT<RealEstateStatus, RealEstateStatusDTO, int> service)
        {
            this.repository = repository;
            this.service = service;
        }

        public async Task<List<RealEstateStatusDTO>> GetAllRealEstateStatusesAsync(Expression<Func<RealEstateStatusDTO, bool>> where = null)
        {
            return await service.GetAllItemsAsync(where);
        }

        public async Task<RealEstateStatusDTO> GetRealEstateStatusByIdAsync(int id)
        {
            return await service.GetItemByIdAsync(id);
        }

        public async Task<RealEstateStatusDTO> GetRealEstateStatusByParamsAsync(Expression<Func<RealEstateStatusDTO, bool>> where)
        {
            return await service.GetItemByParamsAsync(where);
        }

        public async Task<OperationDetails> CreateRealEstateStatusAsync(RealEstateStatusDTO realEstateStatusDto, OperationDetails MessageSuccess, OperationDetails MessageFail)
        {
            return (await service.CreateItemAsync(realEstateStatusDto,
                new RealEstateStatusEquelSpecification(realEstateStatusDto).ToExpression(),
                MessageSuccess,
                MessageFail)).Item1;
        }

        public async Task<OperationDetails> DeleteRealEstateStatusAsync(int id, OperationDetails MessageSuccess, OperationDetails MessageFail)
        {
            return await service.DeleteItemAsync(id,
                MessageSuccess,
                MessageFail);
        }

        public async Task<OperationDetails> UpdateRealEstateStatusAsync(RealEstateStatusDTO realEstateStatusDto, OperationDetails MessageSuccess, OperationDetails MessageFail)
        {
            int idStatusDto = realEstateStatusDto.RealEstateStatusID;
            return await service.UpdateItemAsync(realEstateStatusDto,
                idStatusDto,
                MessageSuccess,
                MessageFail);            
        }

        public async Task<List<RealEstateStatusDTO>> FilterRealEstateStatusAsync(RealEstateStatusFilterModel realEstateStatusFilter)
        {
            List<RealEstateStatusDTO> list = await this.GetAllRealEstateStatusesAsync();
            if (realEstateStatusFilter.RealEstateStatusID != null) list = list.Where(emp => emp.RealEstateStatusID == realEstateStatusFilter.RealEstateStatusID).ToList();
            if (realEstateStatusFilter.RealEstateStatusName != null) list = list.Where(emp => emp.RealEstateStatusName == realEstateStatusFilter.RealEstateStatusName).ToList();
            return list;
        }


        public void Dispose()
        {
            repository.Dispose();
        }
    }
}
