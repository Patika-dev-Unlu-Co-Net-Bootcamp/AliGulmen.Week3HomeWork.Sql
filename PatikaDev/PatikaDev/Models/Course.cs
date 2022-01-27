using System;
using System.Collections.Generic;

namespace PatikaDev.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte DurationWeek { get; set; }
        public byte PassingGrade { get; set; }
        public Int16 Capacity { get; set; }

        public List<Assistant> Assistants { get; set; }
        public List<Participant> Participants { get; set; }
        public List<Teacher> Teachers { get; set; }
        public CourseDate CourseDate { get; set; }

    }

}
