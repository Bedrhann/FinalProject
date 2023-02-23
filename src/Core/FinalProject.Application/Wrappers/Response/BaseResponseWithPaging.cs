

using FinalProject.Application.Wrappers.Paging;

namespace FinalProject.Application.Wrappers.Base
{
    public class BaseResponseWithPaging<T>
    {
        public BaseResponse<T> BaseResponse { get; set; }
        public BasePagingResponse PagingInfo { get; set; }

        public BaseResponseWithPaging(BaseResponse<T> baseResponse, BasePagingResponse pagingInfo)
        {
            BaseResponse = baseResponse;
            PagingInfo = pagingInfo;
        }
    }
}
