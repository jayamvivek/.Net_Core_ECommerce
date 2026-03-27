namespace EcommerceWebAPI.APIResponse
{
    public class JsonResponse
    {
        public object Success(object? data, string message = "Success")
        {
            return new
            {
                Status = "Success",
                Message = message,
                Data = data
            };
        }

        public object Error(string message = "An error occurred")
        {
            return new
            {
                Status = "Error",
                Message = message
            };
        }
    }
}
