using System.Linq;
using TestAutomation.Infrastructure.Context;
using TestAutomation.Infrastructure.Entities;
using TestAutomation.Infrastructure.Repository.Product;

namespace TestAutomation.Infrastructure.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext context;

        public ProductRepository(ProductContext context)
        {
            this.context = context;
        }
        public ProductEntity Get(int id)
        {
            if (id != 0)
            {
                var ret = context.Products.FirstOrDefault(p => p.Id == id);
                return ret;
            }

            return null;
        }
    }
}