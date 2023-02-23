using FinalProject.Application.Interfaces.Repositories.Common;
using FinalProject.Application.Interfaces.Services;
using FinalProject.Application.Wrappers.Base;
using FinalProject.Domain.Entities.Common;
using Mapster;

namespace FinalProject.Persistance.Services
{
    public abstract class BaseCommandService<Dto,Entity> : IBaseCommandService<Dto,Entity> where Entity : BaseEntity
    {
        private readonly ICommandRepository<Entity> _commandRepository;
        private readonly IQueryRepository<Entity> _queryRepository;
        public BaseCommandService(ICommandRepository<Entity> commandRepository, IQueryRepository<Entity> queryRepository)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
        }



        //*******************       INSERT     **********************
        public async Task<BaseResponse<Dto>> InsertAsync(Dto insertResource)
        {

            await _commandRepository.AddAsync(insertResource.Adapt<Entity>());
            await _commandRepository.SaveAsync();

            return new BaseResponse<Dto>(insertResource);
        }



        //*******************       REMOVE     **********************
        public async Task<BaseResponse<Dto>> RemoveAsync(Guid id)
        {
            Entity DeletedProduct = await _queryRepository.GetByIdAsync(id.ToString());
            _commandRepository.Remove(DeletedProduct);
            _commandRepository.SaveAsync();

            return new BaseResponse<Dto>(true);
        }




        //*******************       UPDATE     **********************
        public virtual async Task<BaseResponse<Dto>> UpdateAsync(Guid id, Dto updateResource)
        {
            Entity UpdatedShopList = await _queryRepository.GetByIdAsync(id.ToString());
            bool oldStatus = UpdatedShopList.IsCompleted;
            request.Adapt<UpdateShopListCommandRequest, ShopList>(UpdatedShopList);
            _commandRepository.Update(UpdatedShopList);
            await _commandRepository.SaveAsync();
            if (oldStatus == false && UpdatedShopList.IsCompleted == true)
            {
                UpdatedShopList.Adapt<ShopList, ShopListArchiveDto>();
                _rabbitMq.Publish(UpdatedShopList, "fanout.shoplist");
            }


            BaseResponse response = new()
            {
                Success = true,
                Message = "ShopList Updated"
            };
            return response;


            throw new NotImplementedException();
        }
    }
}
