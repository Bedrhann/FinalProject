﻿using FinalProject.Application.DTOs.Product;
using FinalProject.Application.Interfaces.Services.ProductService;
using FinalProject.Application.Wrappers.Base;
using Mapster;
using MediatR;

namespace FinalProject.Application.Features.ProductFeatures.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, BaseResponse<ProductCreateDto>>
    {
        private readonly IProductCommandService _service;

        public CreateProductCommandHandler(IProductCommandService service)
        {
            _service = service;
        }

        public async Task<BaseResponse<ProductCreateDto>> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {

            return await _service.InsertAsync(request.Adapt<ProductCreateDto>());
        }
    }
}
