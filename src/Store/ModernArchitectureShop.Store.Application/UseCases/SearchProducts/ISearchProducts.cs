namespace ModernArchitectureShop.Store.Application.UseCases.SearchProducts
{
    public interface ISearchProducts
    {
        public string Filter { get; set; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }
    }
}
