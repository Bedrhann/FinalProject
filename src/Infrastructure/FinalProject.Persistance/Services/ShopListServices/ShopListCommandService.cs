using FinalProject.Application.DTOs.ShopList;
using FinalProject.Application.Interfaces.ExternalServices.RabbitMq;
using FinalProject.Application.Interfaces.Repositories.Common;
using FinalProject.Application.Interfaces.Services.ShopListService;
using FinalProject.Application.Wrappers.Base;
using FinalProject.Domain.Entities;
using FinalProject.Persistance.Services.BaseServices;
using Mapster;

namespace FinalProject.Persistance.Services.ShopListServices
{
    public class ShopListCommandService : BaseCommandService<ShopListCommandDto, ShopList>, IShopListCommandService
    {
        private readonly IBaseQueryRepository<ShopList> _queryRepository;
        private readonly IBaseCommandRepository<ShopList> _commandRepository;
        private readonly IRabbitMqPublisher _rabbitMq;

        public ShopListCommandService(IBaseCommandRepository<ShopList> commandRepository, IBaseQueryRepository<ShopList> queryRepository, IRabbitMqPublisher rabbitMq) : base(commandRepository, queryRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
            _rabbitMq = rabbitMq;
        }


        //*******************       REMOVE     **********************
        public async Task<BaseResponse<ShopListCommandDto>> SoftRemoveAsync(Guid id)
        {
            ShopList deletedProduct = await _queryRepository.GetByIdAsync(id.ToString());
            deletedProduct.IsDeleted = true;
            _commandRepository.Update(deletedProduct);
            _commandRepository.SaveAsync();

            return new BaseResponse<ShopListCommandDto>(true);
        }



        //*******************       UPDATE     **********************
        public override async Task<BaseResponse<ShopListCommandDto>> UpdateAsync(Guid id, ShopListCommandDto updateResource)
        {
            ShopList updatedShopList = await _queryRepository.GetByIdAsync(id.ToString());
            bool oldStatus = updatedShopList.IsCompleted;
            updateResource.Adapt<ShopListCommandDto, ShopList>(updatedShopList);
            _commandRepository.Update(updatedShopList);
            await _commandRepository.SaveAsync();
            if (oldStatus == false && updatedShopList.IsCompleted == true)
            {
                updatedShopList.Adapt<ShopList, ShopListQueryDto>();
                _rabbitMq.Publish(updatedShopList, "direct.list");
            }

            return new BaseResponse<ShopListCommandDto>(true);
        }
    }
}
