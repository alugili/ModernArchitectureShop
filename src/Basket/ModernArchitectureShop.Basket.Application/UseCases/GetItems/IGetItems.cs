namespace ModernArchitectureShop.Basket.Application.UseCases.GetItems
{
    public interface IGetItems
    {
        public int PageIndex { get; }
        public int PageSize { get; }
        public string Username { get; }
    }
}
