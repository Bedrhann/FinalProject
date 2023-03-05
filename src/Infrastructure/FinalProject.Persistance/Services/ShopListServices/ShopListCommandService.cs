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
    public class ShopListCommandService : BaseCommandService<ShopListCreateDto, ShopListUpdateDto, ShopList>, IShopListCommandService
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
        public async Task<BaseResponse<object>> SoftRemoveAsync(Guid id)
        {
            ShopList deletedProduct = await _queryRepository.GetByIdAsync(id.ToString());
            deletedProduct.IsDeleted = true;
            _commandRepository.Update(deletedProduct);
            _commandRepository.SaveAsync();

            return new BaseResponse<object>(true);
        }



        //*******************       UPDATE     **********************
        override public async Task<BaseResponse<ShopListUpdateDto>> UpdateAsync(Guid id, ShopListUpdateDto updateResource)
        {
            ShopList updatedShopList = await _queryRepository.GetByIdAsync(id.ToString());
            bool oldStatus = updatedShopList.IsCompleted;
            updateResource.Adapt<ShopListUpdateDto, ShopList>(updatedShopList);
            _commandRepository.Update(updatedShopList);
            await _commandRepository.SaveAsync();
            if (oldStatus == false && updatedShopList.IsCompleted == true)
            {
                ArchivedShopList archivedShopList = updatedShopList.Adapt<ShopList, ArchivedShopList>();
                _rabbitMq.Publish(archivedShopList, "direct.list");
            }
            return new BaseResponse<ShopListUpdateDto>(true);
        }
    }
}
