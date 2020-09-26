using TBSTech.Data;
using TBSTech.GenericRepository;
using TBSTech.Models;

namespace TBSTech.Repository
{
    public class VideoRepository : GenericRepository<Video>, IVideoRepository
    {
        public VideoRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}