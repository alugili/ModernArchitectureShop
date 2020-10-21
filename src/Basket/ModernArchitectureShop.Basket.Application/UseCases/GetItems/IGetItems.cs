namespace ModernArchitectureShop.Basket.Application.UseCases.GetItems
{
    public interface IGetItems
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string Username { get; set; }
    }
}
