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
        public string CourseDuration { get; set; }
        public string Time1 { get; set; }
        public string Time2 { get; set; }
        public string Time3 { get; set; }
        public string ImageUrl { get; set; }

    }
}