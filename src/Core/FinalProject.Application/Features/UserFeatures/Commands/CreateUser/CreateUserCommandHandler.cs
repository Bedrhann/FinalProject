using FinalProject.Application.DTOs.User;
using FinalProject.Application.Interfaces.Services.UserServices;
using FinalProject.Application.Wrappers.Base;
using Mapster;
using MediatR;

namespace FinalProject.Application.Features.UserFeatures.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, BaseResponse<UserCommandDto>>
    {
        private readonly IUserService _service;
        public CreateUserCommandHandler(IUserService service)
        {
            _service = service;
        }

        public async Task<BaseResponse<UserCommandDto>> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            return await _service.CreateAsync(request.Adapt<UserCommandDto>());
        }
    }
}
