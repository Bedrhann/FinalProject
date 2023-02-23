﻿using FinalProject.Application.DTOs.ShopList;
using FinalProject.Application.Wrappers.Base;
using MediatR;

namespace FinalProject.Application.Features.ShopListFeatures.Commands.DeleteShopList
{
    public class DeleteShopListCommandRequest : IRequest<BaseResponse<ShopListCommandDto>>
    {
        public Guid Id { get; set; }
    }
}
