using FinalProject.Application.DTOs.ShopList;
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

        public ShopListCommandService(IBaseCommandRepository<ShopList> commandRepository, IBaseQueryRepository<ShopList> queryRepository) : base(commandRepository,queryRepository )
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
        public override async Task<BaseResponse<ShopListCommandDto>> UpdateAsync(Guid id, ShopListCommandDto updateResource)
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
