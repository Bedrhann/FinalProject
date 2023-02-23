using FinalProject.Application.DTOs.User;
using FinalProject.Application.Interfaces.Services.UserServices;
using FinalProject.Application.Wrappers.Base;
using FinalProject.Domain.Models;
using Mapster;
using MediatR;

namespace FinalProject.Application.Features.UserFeatures.Commands.CheckUser
{
    public class CheckUserCommandHandler : IRequestHandler<CheckUserCommandRequest, BaseResponse<Token>>
    {
        private readonly IUserService _service;
        public CheckUserCommandHandler(IUserService service)
        {
            _service = service;
        }

        public async Task<BaseResponse<Token>> Handle(CheckUserCommandRequest request, CancellationToken cancellationToken)
        {
            return await _service.CheckAsync(request.Adapt<UserCommandDto>());
        }
    }
}
