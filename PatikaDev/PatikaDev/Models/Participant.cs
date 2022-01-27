using System.Collections.Generic;

namespace PatikaDev.Models
{
    public class Participant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }

        public List<Course> Courses { get; set; }
    }
}
