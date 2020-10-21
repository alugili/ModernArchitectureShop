namespace ModernArchitectureShop.Store.Application.UseCases.GetStores
{
    public interface IGetStores
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
