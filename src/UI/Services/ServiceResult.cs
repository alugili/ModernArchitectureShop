namespace ModernArchitectureShop.BlazorUI.Services
{
    public class ServiceResult<T>
    {
        public int StatusCode { get; set; }

        public string Error { get; set; }

        public T Content { get; set; }
    }
}
