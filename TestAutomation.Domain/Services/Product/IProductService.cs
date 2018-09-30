namespace TestAutomation.Domain.Services.Product
{
    public interface IProductService
    {
        Domain.Models.Product FindByProductId(int v);
    }
}