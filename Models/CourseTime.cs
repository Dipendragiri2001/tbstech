using System;

namespace TBSTech.Models
{
    public class CourseTime
    {
        
        public int Id { get; set; }
         public string MorningCourse { get; set; }
        public string DayCourse { get; set; }
        public string EveningCourse { get; set; }

        public Course Course { get; set; }
        public int CourseId { get; set; }
    }
}