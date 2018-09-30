using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestAutomation.Domain.Models;
using TestAutomation.Domain.Services.Product;
using TestAutomation.Infrastructure.Context;
using TestAutomation.Infrastructure.Entities;
using TestAutomation.Infrastructure.Repository;
using TestAutomation.Infrastructure.Repository.Product;
using Xunit;

namespace TestAutomation.Tests.IT
{
    public class ProductServiceTest
    {
        private readonly ServiceCollection services;
        public ProductServiceTest()
        {
            var ctx = InitContext();
            this.services = new ServiceCollection();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ProductContext>(f => { return ctx; });
        }

        public ProductContext InitContext()
        {
            var builder = new DbContextOptionsBuilder<ProductContext>().UseInMemoryDatabase("ProductContext");

            var context = new ProductContext(builder.Options);
            var books = Enumerable.Range(1, 5)
                .Select(i => new ProductEntity { Id = i, Name = $"Product{i}", PriceTaxExcluded= 200 * i , PriceTaxIncluded = 160 * i });
            context.Products.AddRange(books);
            int changed = context.SaveChanges();
            return  context;
        }

        [Fact]
        public void ProductServiceFindValidProductId()
        {

            var expected = new Product
            {
                Id = 1,
                Name = "product1",
                Price = 160
            };

            IProductService service = new ProductService(services.BuildServiceProvider().GetService<IProductRepository>());

            var actuel = service.FindByProductId(1);

            Assert.NotNull(actuel);
            Assert.IsType<Product>(actuel);
            Assert.Equal(actuel.Id, expected.Id);
            Assert.Equal(actuel.Name, expected.Name, true);
            Assert.Equal(actuel.Price, expected.Price);
        }
    }
}
