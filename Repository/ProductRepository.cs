using System.Linq;
using Microsoft.AspNetCore.Http;
using TBSTech.Areas.Admin.Controllers;
using TBSTech.Data;
using TBSTech.GenericRepository;
using TBSTech.Models;

namespace TBSTech.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _context;
    

        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        
            _context = context;
        }
      
        
    }
}