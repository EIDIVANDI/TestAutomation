using NSubstitute;
using TestAutomation.Domain.Models;
using TestAutomation.Domain.Services.Product;
using TestAutomation.Infrastructure.Entities;
using TestAutomation.Infrastructure.Repository.Product;
using Xunit;

namespace TestAutomation.Teats.UT
{
    public class ProductServiceTest
    {
        private readonly IProductRepository productRepository;

        public ProductServiceTest()
        {
            productRepository = Substitute.For<IProductRepository>();
        }

        [Fact]
        public void ProductServiceFindValidProductId()
        {
            var expected = new Product
            {
                Id = 1,
                Name = "product",
                Price = 2700
            };

            productRepository.Get(Arg.Any<int>()).Returns(new ProductEntity
            {
                Id = 1,
                Name = "product",
                PriceTaxIncluded = 2700,
                PriceTaxExcluded = 2200
            });

            IProductService service = new ProductService(productRepository);

            var actuel = service.FindByProductId(1);

            Assert.NotNull(actuel);
            Assert.IsType<Product>(actuel);
            Assert.Equal(actuel.Id, expected.Id);
            Assert.Equal(actuel.Name, expected.Name);
            Assert.Equal(actuel.Price, expected.Price);
        }

    }
}
