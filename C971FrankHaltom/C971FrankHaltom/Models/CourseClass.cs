using System;
using SQLite;
using System.Collections.Generic;
using System.Text;

namespace C971FrankHaltom.Models
{
    public class CourseClass
    {
        [PrimaryKey, AutoIncrement]
        public int CourseId { get; set; }
            public string CourseTitle { get; set; }

            public DateTime CourseStartDate { get; set; }

            public DateTime CourseEndtDate { get; set; }

            public string StatusOfCourse { get; set; }

            public string CourseNotes { get; set; }

            public string InstructorName { get; set; }

            public string InstructorPhone { get; set; }

            public string InstructorEmail { get; set; }

            public string ObjectiveAssesmentName { get; set; }

            public DateTime ObjectiveAssesmentDueDate { get; set; }

            public string PerformanceAssesmentName { get; set; }

            public DateTime PerformanceAssesmentDueDate { get; set; }




           
    }

}

