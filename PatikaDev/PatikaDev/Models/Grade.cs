namespace PatikaDev.Models
{
    public class Grade
    {
        public int Id { get; set; }
        public int CourseStudentId { get; set; }
        public CourseStudent CourseStudent { get; set; }
        public byte Mark { get; set; }
    }
}
