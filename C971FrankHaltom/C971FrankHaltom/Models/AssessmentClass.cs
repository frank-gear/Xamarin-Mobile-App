using System;
using SQLite;
using System.Collections.Generic;
using System.Text;

namespace C971FrankHaltom.Models
{
    public class AssessmentClass
    {
        public AssessmentClass()
        {

        }
        public AssessmentClass( string name, string type, DateTime dueDate)
        {
            
            Name = name;
            Type = type;
            DueDate = dueDate;
        }

        [PrimaryKey, AutoIncrement]
        public int AssesmentId { get; set; }
        public string Name { get; set; }

        public string Type { get; set; }

        public DateTime DueDate { get; set; }
    }



}
