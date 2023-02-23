using FinalProject.Application.DTOs.Base;
using FinalProject.Application.Interfaces.Repositories.ShopListRepositories;
using FinalProject.Application.Wrappers.Base;
using FinalProject.Domain.Entities;
using Mapster;
using MediatR;

namespace FinalProject.Application.Features.ShopListFeatures.Commands.CreateShopList
{
    public class CreateShopListCommandHandler : IRequestHandler<CreateShopListCommandRequest, BaseResponse<BaseCreateDto>>
    {
        private readonly IShopListCommandRepository _repository;

        public CreateShopListCommandHandler(IShopListCommandRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseResponse<BaseCreateDto>> Handle(CreateShopListCommandRequest request, CancellationToken cancellationToken)
        {
            ShopList NewShopList = request.Adapt<ShopList>();
            await _repository.AddAsync(NewShopList);
            await _repository.SaveAsync();

            var a = new BaseResponse<>();

            BaseResponse response = new()
            {
                Success = true,
                Message = "ShopList Added"
            };
            return response;
            throw new NotImplementedException();
        }
    }
}
