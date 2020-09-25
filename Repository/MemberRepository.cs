using TBSTech.Data;
using TBSTech.GenericRepository;
using TBSTech.Models;

namespace TBSTech.Repository
{
    public class MemberRepository : GenericRepository<Member>, IMemberRepository
    {
        public MemberRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}