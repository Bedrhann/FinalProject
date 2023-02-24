using FinalProject.Application.Wrappers.Base;
using FinalProject.Domain.Models;
using MediatR;

namespace FinalProject.Application.Features.UserFeatures.Commands.CheckUser
{
    public class CheckUserCommandRequest : IRequest<BaseResponse<Token>>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
