using FinalProject.Application.Interfaces.Services;
using FinalProject.Application.Interfaces.Services.UserServices;
using FinalProject.Application.Models.JwtToken;
using FinalProject.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace FinalProject.Application.Features.UserFeatures.Commands.CheckUser
{
    public class CheckUserCommandHandler : IRequestHandler<CheckUserCommandRequest, CheckUserCommandResponse>
    {
        private readonly IUserService _service;
        public CheckUserCommandHandler(IUserService service)
        {
            _service = service;
        }

        public async Task<CheckUserCommandResponse> Handle(CheckUserCommandRequest request, CancellationToken cancellationToken)
        {
            _service.CheckAsync(,)

        }
    }
}
