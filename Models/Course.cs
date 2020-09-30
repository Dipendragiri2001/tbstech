using System;

namespace TBSTech.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public string CourseLink { get; set; }
        public string CourseDescription { get; set; }
        public DateTime CourseStartTime { get; set; }
        public DateTime CourseEndTime { get; set; }
        
    }
}