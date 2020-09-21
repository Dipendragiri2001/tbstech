using TBSTech.Data;
using TBSTech.GenericRepository;
using TBSTech.Models;

namespace TBSTech.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}