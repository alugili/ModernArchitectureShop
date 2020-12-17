namespace ModernArchitectureShop.Basket.Application.UseCases.GetItemsInPage
{
    public interface IGetItemsPage
    {
        public int PageIndex { get; }
        public int PageSize { get; }
        public string Username { get; }
    }
}
