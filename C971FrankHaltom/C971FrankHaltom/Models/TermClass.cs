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
            
        
    }
}
