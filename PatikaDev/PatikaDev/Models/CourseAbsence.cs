using System;

namespace PatikaDev.Models
{
    public class CourseAbsence
    {
        public int Id { get; set; }
        public int CourseStudentId { get; set; }
        public CourseStudent CourseStudent { get; set; }
        public DateTime Date { get; set; }
        public bool Present { get; set; }

    }
}
