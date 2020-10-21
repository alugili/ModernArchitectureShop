namespace ModernArchitectureShop.Store.Application.UseCases.GetProducts
{
    public interface IGetProducts
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
