using Ecommerce.Core.Entities;
using Ecommerce.Core.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Repositories
{
    public interface IProductRepository: IRepository<Product>
    {        
        Task<IEnumerable<Product>> GetProductByNameAsync(string productName);
        Task<Product> GetProductByIdAsync(int id);
    }
}
