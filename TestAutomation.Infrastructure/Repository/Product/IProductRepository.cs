using System;
using TestAutomation.Infrastructure.Entities;

namespace TestAutomation.Infrastructure.Repository.Product
{
    public interface IProductRepository
    {
        ProductEntity Get(int id);
    }
}