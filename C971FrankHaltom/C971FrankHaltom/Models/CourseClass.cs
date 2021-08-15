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

            public int ObjectiveId { get; set; }
            
            public int PerformanceId { get; set; }

        public CourseClass(string courseTitle, DateTime courseStartDate, DateTime courseEndtDate, string statusOfCourse, string courseNotes, string instructorName, string instructorPhone, string instructorEmail, int Objective, int Performance)
        {
            CourseTitle = courseTitle;
            CourseStartDate = courseStartDate;
            CourseEndtDate = courseEndtDate;
            StatusOfCourse = statusOfCourse;
            CourseNotes = courseNotes;
            InstructorName = instructorName;
            InstructorPhone = instructorPhone;
            InstructorEmail = instructorEmail;
            ObjectiveId = Objective;
            PerformanceId = Performance;
        }

        public CourseClass()
        {
        }
    }

}

