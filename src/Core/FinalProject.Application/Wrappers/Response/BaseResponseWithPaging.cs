

using FinalProject.Application.Wrappers.Paging;

namespace FinalProject.Application.Wrappers.Base
{
    public class BaseResponseWithPaging<T>
    {
        [System.Text.Json.Serialization.JsonPropertyName("baseResponse")]
        public BaseResponse<T> BaseResponse { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("pagingInfo")]
        public BasePagingResponse PagingInfo { get; set; }

        public BaseResponseWithPaging(BaseResponse<T> response, BasePagingResponse paging)
        {
            BaseResponse = response;
            PagingInfo = paging;
        }
    }
}
