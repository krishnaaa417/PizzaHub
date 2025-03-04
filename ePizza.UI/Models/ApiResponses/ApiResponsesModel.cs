namespace ePizza.UI.Models.ApiResponses
{
    public class ApiResponsesModel<T>
    {
        public bool Success { get; set; }

        public T Data { get; set; }

        public string Message { get; set; }

        public ApiResponsesModel(bool success, T data, string message)
        {
            Success = success;
            Data = data;
            Message = message;
        }
    }
}
