using System;
using System.Collections.Generic;

namespace TBSTech.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public string CourseLink { get; set; }
        public string CourseDescription { get; set; }
        public DateTime CourseStartDate { get; set; }
        public string ImageUrl { get; set; }
        public List<CourseTime> CourseTimes {get; set;}
        
    }
}