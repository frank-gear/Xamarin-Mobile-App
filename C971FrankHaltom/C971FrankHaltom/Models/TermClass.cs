using System;
using C971FrankHaltom.Models;
using SQLite;
using System.Collections.Generic;
using System.Text;

namespace C971FrankHaltom.Models
{
    public class TermClass
    {
        [PrimaryKey, AutoIncrement]
        public int TermId { get; set; }
            public string TermTitle { get; set; }

            public DateTime TermStartDate { get; set; }

            public DateTime TermEndtDate { get; set; }
         
            public int Course1 { get; set; }
            public int Course2 { get; set; }
            public int Course3 { get; set; }
            public int Course4 { get; set; }
            public int Course5 { get; set; }
            public int Course6 { get; set; }

        public TermClass(string termTitle, DateTime termStartDate, DateTime termEndtDate, int course1, int course2, int course3, int course4, int course5, int course6)
        {
            TermTitle = termTitle;
            TermStartDate = termStartDate;
            TermEndtDate = termEndtDate;
            Course1 = course1;
            Course2 = course2;
            Course3 = course3;
            Course4 = course4;
            Course5 = course5;
            Course6 = course6;
        }

        public TermClass()
        {
        }
    }
}
