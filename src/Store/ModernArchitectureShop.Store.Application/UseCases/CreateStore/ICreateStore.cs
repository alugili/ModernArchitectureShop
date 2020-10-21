namespace ModernArchitectureShop.Store.Application.UseCases.CreateStore
{
    public interface ICreateStore
    {
        public string Name { get; set; }
        public string Location { get; set; }
    }
}
