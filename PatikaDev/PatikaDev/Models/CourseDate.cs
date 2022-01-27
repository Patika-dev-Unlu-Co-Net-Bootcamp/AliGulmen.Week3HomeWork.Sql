using System;

namespace PatikaDev.Models
{
    public class CourseDate
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
       

    }
}
