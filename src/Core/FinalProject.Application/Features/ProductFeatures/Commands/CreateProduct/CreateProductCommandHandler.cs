using FinalProject.Application.DTOs.Base;
using FinalProject.Application.Interfaces.Repositories.ProductRepositories;
using FinalProject.Application.Wrappers.Base;
using FinalProject.Domain.Entities;
using Mapster;
using MediatR;

namespace FinalProject.Application.Features.ProductFeatures.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, BaseResponse<BaseCreateDto>>
    {
        private readonly IProductCommandRepository _repository;

        public CreateProductCommandHandler(IProductCommandRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseResponse<BaseCreateDto>> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            Product NewProduct = request.Adapt<Product>();
            bool result = await _repository.AddAsync(NewProduct);
            await _repository.SaveAsync();

            
            return new BaseResponse<BaseCreateDto>(result);
        }
    }
}
