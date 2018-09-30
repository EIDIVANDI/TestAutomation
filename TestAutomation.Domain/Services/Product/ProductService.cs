using TestAutomation.Domain.Models;
using TestAutomation.Infrastructure.Repository.Product;

namespace TestAutomation.Domain.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository repository;

        public ProductService(IProductRepository repository)
        {
            this.repository = repository;
        }

        public Models.Product FindByProductId(int id)
        {
            Models.Product product = new Models.Product();
            if (id != 0 )
            {
                var entity = repository.Get(id);
                if (entity != null)
                {
                    product.Id = entity.Id;
                    product.Name = entity.Name;
                    product.Price = entity.PriceTaxIncluded;
                }
            }
            return product;
        }
    }
}