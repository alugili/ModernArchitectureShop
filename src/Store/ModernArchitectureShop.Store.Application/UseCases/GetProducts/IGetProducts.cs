namespace ModernArchitectureShop.Store.Application.UseCases.GetProducts
{
    public interface IGetProducts
    {
        public int PageIndex { get; }
        public int PageSize { get; }
    }
}
