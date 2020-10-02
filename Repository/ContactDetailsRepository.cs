using TBSTech.Data;
using TBSTech.GenericRepository;
using TBSTech.Models;

namespace TBSTech.Repository
{
    public class ContactDetailsRepository : GenericRepository<ContactDetail>, IContactDetailsRepository
    {
        public ContactDetailsRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}