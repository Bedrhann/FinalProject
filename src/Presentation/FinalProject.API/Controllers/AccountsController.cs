using FinalProject.Application.DTOs.User;
using FinalProject.Application.Features.UserFeatures.Commands.CheckUser;
using FinalProject.Application.Features.UserFeatures.Commands.CreateUser;
using FinalProject.Application.Wrappers.Base;
using FinalProject.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.API.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommandRequest request)
        {
            BaseResponse<UserCommandDto> response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> CheckUser([FromBody] CheckUserCommandRequest request)
        {
            BaseResponse<Token> response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
