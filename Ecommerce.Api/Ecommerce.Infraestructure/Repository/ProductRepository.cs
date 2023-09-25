using Ecommerce.Core.Entities;
using Ecommerce.Core.Repositories;
using Ecommerce.Infraestructure.Data;
using Ecommerce.Infraestructure.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infraestructure.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly EcommerceContext _dbContext;
        public ProductRepository(EcommerceContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Product>> GetProductByNameAsync(string productName)
        {
            return await _dbContext.Products
                .Where(x => x.ProductName.Contains(productName))
                .ToListAsync();
        }
        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _dbContext.Products
                .Where(x => x.Id == id)
                .FirstAsync();
        }
    }
}
