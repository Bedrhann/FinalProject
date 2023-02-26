using FinalProject.Application.DTOs.User;
using FinalProject.Application.Interfaces.Services.UserServices;
using FinalProject.Application.Wrappers.Base;
using MediatR;

namespace FinalProject.Application.Features.UserFeatures.Queries.GetAllUser
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQueryRequest, BaseResponseWithPaging<List<UserQueryDto>>>
    {
        private readonly IUserService _service;
        public GetAllUserQueryHandler(IUserService service)
        {
            _service = service;
        }

        public async Task<BaseResponseWithPaging<List<UserQueryDto>>> Handle(GetAllUserQueryRequest request, CancellationToken cancellationToken)
        {
            return await _service.GetAllAsync(request);
        }
    }
}
