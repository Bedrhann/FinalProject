

namespace FinalProject.Application.Wrappers.Base
{
    //public class BaseResponse
    //{
    //    [System.Text.Json.Serialization.JsonPropertyName("success")]
    //    public bool Success { get; set; }
    //    [System.Text.Json.Serialization.JsonPropertyName("message")]
    //    public string Message { get; set; }
    //}
    public class BaseResponse<T>
    {
        public bool Success { get; private set; }
        public List<string> Message { get; private set; }
        public T Response { get; private set; }

        public BaseResponse()
        {
            Response = default;
            Success = false;
            Message = new List<string>() { "Fault" };
        }
        public BaseResponse(bool isSuccess)
        {
            Response = default;
            Success = isSuccess;
            Message = isSuccess ? new List<string>() { "Success" } : new List<string>() { "Fault" };
        }

        public BaseResponse(T resource)
        {
            Success = true;
            Message = new List<string>() { "Success" };
            Response = resource;
        }

        public BaseResponse(string message)
        {
            Success = false;
            Response = default;

            if (!string.IsNullOrWhiteSpace(message))
            {
                Message = new List<string>() { message };
            }
        }

        public BaseResponse(List<string> messages)
        {
            this.Success = false;
            this.Response = default;
            this.Message = messages ?? new List<string>() { "Fault" };
        }
    }
}
