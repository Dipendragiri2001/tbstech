using TBSTech.Data;
using TBSTech.GenericRepository;
using TBSTech.Models;

namespace TBSTech.Repository
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        public CourseRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}