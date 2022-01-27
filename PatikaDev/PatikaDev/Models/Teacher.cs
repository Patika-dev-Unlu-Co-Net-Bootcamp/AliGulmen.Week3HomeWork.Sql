using System.Collections.Generic;

namespace PatikaDev.Models
{
    public class Teacher : BasePersonEntity
    {
      
        public List<Course> Courses { get; set; }
       
    }
}
