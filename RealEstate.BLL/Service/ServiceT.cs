using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstateAgency.BLL.Infrastuctures;
using RealEstateAgency.DAL.Interfaces;
using System.Linq.Expressions;
using System.Data.Entity;
using AutoMapper;
using RealEstateAgency.DAL.Entities;
using RealEstateAgency.BLL.EntitiesDTO;
using System.Reflection;
using RealEstateAgency.BLL.Services;
using RealEstateAgency.BLL.Interfaces;
using Ninject;
using RealEstateAgency.BLL.Specifications;

namespace RealEstateAgency.BLL.Service
{
    public class ServiceT<TEntity,TEntityDto, TType> : IServiceT<TEntity,TEntityDto, TType> 
        where TEntity : class
        where TEntityDto:class
    {
        private IRepository<TEntity, TType> repository;
        private IUnitOfWorkIdentity identity;
        IKernel kernel;
        public ServiceT(IRepository<TEntity, TType> repo, IUnitOfWorkIdentity identity,IKernel kernel)
        {
            repository= repo;
            this.identity = identity;
            this.kernel = kernel;
            //Mapper.Initialize(cfg =>
            //{
            //    cfg.CreateMap<TEntity, TEntityDto>();
            //    cfg.CreateMap<TEntityDto, TEntity>();
            //});
            //Mapper.Initialize(cfg => cfg.CreateMap<TEntity, TEntityDto>());
            //Mapper.Initialize(cfg => cfg.CreateMap<TEntityDto, TEntity>());
        }
        public TDest Map<TSource, TDest>(TSource viewModel)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<TSource, TDest>());
            TDest result = Mapper.Map<TSource, TDest>(viewModel);

            return result;
        }
        public Expression<Func<TSource, bool>> MapExpression<TSource, TDest>(Expression<Func<TDest, bool>> dtoExpression)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<TSource, TDest>());
            Expression<Func<TSource, bool>> expression = Mapper.Map<Expression<Func<TSource, bool>>>(dtoExpression);

            return expression;
        }
        public async Task<List<TEntityDto>> GetAllItemsAsync(Expression<Func<TEntityDto, bool>> where = null)
        {
            var expression = MapExpression<TEntity,TEntityDto>(where);
          
            var AllItemEntities = await repository.FindAllAsync(expression);

            Mapper.Initialize(cfg => cfg.CreateMap<TEntity, TEntityDto>());
            var AllItemEntitiesDto = Mapper.Map<IEnumerable<TEntity>, List<TEntityDto>>(AllItemEntities);

            return AllItemEntitiesDto;
        }

        public async Task<TEntityDto> GetItemByIdAsync(TType idDb)
        {
            
            TEntity ItemEntity = await repository.FindByIdAsync(idDb);

            TEntityDto ItemEntityDto = Map<TEntity, TEntityDto>(ItemEntity);
            return ItemEntityDto;
        }
        public async Task<TEntityDto> GetItemByParamsAsync(Expression<Func<TEntityDto, bool>> where)
        {
            var expression = MapExpression<TEntity, TEntityDto>(where);

            TEntity ItemEntity = await repository.FindOneAsync(expression);

            TEntityDto ItemEntityDto = Map<TEntity, TEntityDto>(ItemEntity);

            return ItemEntityDto;
        }
        public async Task<OperationDetails> CreateAccountUserAsync(TEntityDto PersonDto,
            OperationDetails MessageSuccess, OperationDetails MessageFail, Expression<Func<TEntity, bool>> where=null)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<TEntityDto, TEntity>()
            .ForMember("PersonId", f => f.MapFrom(ctx=>(ctx as PersonAbstractDTO).PersonId))
            .ForMember("Name", f => f.MapFrom(ctx => (ctx as PersonAbstractDTO).Name))
            .ForMember("Surname", f => f.MapFrom(ctx => (ctx as PersonAbstractDTO).Surname))
            .ForMember("Patronumic", f => f.MapFrom(ctx => (ctx as PersonAbstractDTO).Patronumic))
            .ForMember("PhoneNumber", f => f.MapFrom(ctx => (ctx as PersonAbstractDTO).PhoneNumber))
            .ForMember("AddressID", f => f.MapFrom(ctx => (ctx as PersonAbstractDTO).AddressID))       
            .AfterMap((dest, src) => {
                if (dest is EmployeeDTO)
                {
                    (src as Employee).EmployeePostID = (dest as EmployeeDTO).EmployeePostID;
                    (src as Employee).EmployeeStatusID = (dest as EmployeeDTO).EmployeeStatusID;
                    (src as Employee).StateOnline = (dest as EmployeeDTO).StateOnline;
                }
            })
            );
           
            ApplicationUser useR = await identity.AppUserManager.FindByEmailAsync((PersonDto as PersonAbstractDTO).Email);
            TEntity ItemUseR = await repository.FindOneAsync(where);
            if (useR == null && ItemUseR==null)
            {
                useR = new ApplicationUser { Email = (PersonDto as PersonAbstractDTO).Email, UserName = (PersonDto as PersonAbstractDTO).Email };
                var result = await identity.AppUserManager.CreateAsync(useR, (PersonDto as PersonAbstractDTO).Password);

                if (!await identity.RoleManager.RoleExistsAsync((PersonDto as PersonAbstractDTO).Role))
                {
                    await identity.RoleManager.CreateAsync(new ApplicationRole((PersonDto as PersonAbstractDTO).Role));
                }

                if (result.Errors.Count() > 0)
                    return new OperationDetails(false, result.Errors.FirstOrDefault(), "");

                await identity.AppUserManager.AddToRoleAsync(useR.Id, (PersonDto as PersonAbstractDTO).Role);

                (PersonDto as PersonAbstractDTO).PersonId = useR.Id;

                TEntity user = Map<TEntityDto, TEntity>(PersonDto);
                repository.Create(user);

                await repository.SaveChangesAsync();

                if (PersonDto is EmployeeDTO)
                {
                   await kernel.Get<IEmployeeDismissService>().CreateEmployeeDismissAsync(
                      new EmployeeDismissDTO()
                      {
                         EmployeeId = useR.Id,
                         EmploymentDate = DateTime.Now
                      },
                      new EmployeeDismissMessageSpecification().ToSuccessCreateMessage(),
                      new EmployeeDismissMessageSpecification().ToFailCreateMessage());
                }
                                        
                return new OperationDetails
                        (
                         MessageSuccess.Succedeed,
                         MessageSuccess.Message,
                         MessageSuccess.Property,
                         useR.Id);
            }
            else
            {
                return MessageFail;
            }
        }
        public async Task<Tuple<OperationDetails,TEntityDto>> CreateItemAsync(TEntityDto ItemDto,
            Expression<Func<TEntity, bool>> where,OperationDetails MessageSuccess, OperationDetails MessageFail)
        {
            TEntity Item = await repository.FindOneAsync(where);          
            if (Item == null)
            {
                TEntity itemCreate = Map<TEntityDto, TEntity>(ItemDto); 
                repository.Create(itemCreate);
                await repository.SaveChangesAsync();
                var GetLastItem = (await this.GetAllItemsAsync()).LastOrDefault();
                return Tuple.Create<OperationDetails, TEntityDto>(MessageSuccess, GetLastItem);
            }
            else
            {
                TEntityDto ItemDtos = Map<TEntity, TEntityDto>(Item);
                return Tuple.Create<OperationDetails, TEntityDto>(MessageSuccess, ItemDtos);
            }
        }

        public async Task<OperationDetails> DeleteItemAsync(TType id, OperationDetails MessageSuccess, OperationDetails MessageFail)
        {
            TEntity Item = await repository.FindByIdAsync(id);
            if (Item == null)
            {
                return MessageFail;
            }
            else
            {
                await repository.DeleteAsync(id);
                await repository.SaveChangesAsync();
                return MessageSuccess;
            }
        }
              
        public async Task<OperationDetails> UpdateItemAsync(TEntityDto ItemDto,TType idDto,
                                                            OperationDetails MessageSuccess, OperationDetails MessageFail)
        {
            TEntity ItemEntity = await repository.FindByIdAsync(idDto);
            if (ItemEntity != null)
            {
                ItemEntity = Map<TEntityDto, TEntity>(ItemDto);
                repository.Update(ItemEntity);
                await repository.SaveChangesAsync();

                return MessageSuccess;
            }
            else
            {
                return MessageFail;
            }
        }

        public void Dispose()
        {
            repository.Dispose();
        }
    }
}
