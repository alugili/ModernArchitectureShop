namespace ModernArchitectureShop.Store.Application.UseCases.SearchProducts
{
    public interface ISearchProducts
    {
        public string Filter { get; }

        public int PageIndex { get; }

        public int PageSize { get; }
    }
}
