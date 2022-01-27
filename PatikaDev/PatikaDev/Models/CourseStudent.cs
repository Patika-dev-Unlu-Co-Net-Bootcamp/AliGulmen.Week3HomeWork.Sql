namespace PatikaDev.Models
{
    public class CourseStudent
    {
        /*
         * In normal case, entity framework able to create this table itself. 
         * But we are going to control and use this table in different places
         * So, we create manually. 
        
         */
        public int Id { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
