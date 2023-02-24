using FinalProject.Application.DTOs.ShopList;
using FinalProject.Application.Interfaces.Repositories.Common;
using FinalProject.Application.Interfaces.Services.ShopListService;
using FinalProject.Application.Wrappers.Base;
using FinalProject.Domain.Entities;
using Mapster;

namespace FinalProject.Persistance.Services.ShopListServices
{
    public class ShopListCommandService : BaseCommandService<ShopListCommandDto, ShopList>, IShopListCommandService
    {
        private readonly IQueryRepository<ShopList> _queryRepository;
        private readonly ICommandRepository<ShopList> _commandRepository;

        public ShopListCommandService(ICommandRepository<ShopList> commandRepository, IQueryRepository<ShopList> queryRepository) : base(commandRepository,queryRepository )
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
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
        public async Task<BaseResponse<ShopListCommandDto>> UpdateAsync(Guid id, ShopListCommandDto updateResource)
        {
            ShopList UpdatedShopList = await _queryRepository.GetByIdAsync(id.ToString());
            bool oldStatus = UpdatedShopList.IsCompleted;
            updateResource.Adapt<ShopListCommandDto, ShopList>(UpdatedShopList);
            _commandRepository.Update(UpdatedShopList);
            await _commandRepository.SaveAsync();
            if (oldStatus == false && UpdatedShopList.IsCompleted == true)
            {
                UpdatedShopList.Adapt<ShopList, ShopListQueryDto>();
               // _rabbitMq.Publish(UpdatedShopList, "fanout.shoplist");
               //TODO rABİİT İŞLERİ VAR
            }

            return new BaseResponse<ShopListCommandDto>(true);
        }
    }
}
