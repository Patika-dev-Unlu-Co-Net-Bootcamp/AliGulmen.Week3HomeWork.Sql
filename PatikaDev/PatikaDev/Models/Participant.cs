using System.Collections.Generic;

namespace PatikaDev.Models
{
    public class Participant : BasePersonEntity
    {
     
        public List<Course> Courses { get; set; }
    }
}
