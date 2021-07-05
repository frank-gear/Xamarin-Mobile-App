using SQLite;
using C971FrankHaltom.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace C971FrankHaltom.Services
{
   public static class DataClass
    {
        static SQLiteAsyncConnection db;
        public static async Task Init()
        {
            if (db != null)
                return;

            //path to db
            string databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TermData.db3");
            //var databasePath = Path.Combine(Xamarin.Essentials.FileSystem.AppDataDirectory, "TermData.db");
            db = new SQLiteAsyncConnection(databasePath);
            await db.CreateTableAsync<TermClass>();
            await db.CreateTableAsync<CourseClass>();
            
            await AddTerm("Term 1", new DateTime(2021, 8, 01), new DateTime(2021, 12, 01), 0, 1, 2, 3, 4, 5);
            await ModifyCourse("MobileAppDevelopment C971", new DateTime(2021, 8, 01), new DateTime(2021, 12, 01), "in progress", "Do your best!", "Billy Frank Haltom", "(423)782-7613", "bhaltom@wgu.edu", "MidTermTest", new DateTime(2021, 10, 01), "FinalProject", new DateTime(2021, 11, 25));
            await ModifyCourse("History101", new DateTime(2021, 8, 01), new DateTime(2021, 12, 01), "in progress", "Do your best!", "Sarah", "(888)888-8888", "teach3@gmail.com", "MidTermTest", new DateTime(2021, 10, 01), "FinalProject", new DateTime(2021, 11, 25));
            await ModifyCourse("Dancing101", new DateTime(2021, 8, 01), new DateTime(2021, 12, 01), "in progress", "Do your best!", "Jess", "(222)222-2222", "teach5@gmail.com", "MidTermTest", new DateTime(2021, 10, 01), "FinalProject", new DateTime(2021, 11, 25));
            await ModifyCourse("Lit101", new DateTime(2021, 8, 01), new DateTime(2021, 12, 01), "in progress", "Do your best!", "Larry", "(666)666-6666", "teach1@gmail.com", "MidTermTest", new DateTime(2021, 10, 01), "FinalProject", new DateTime(2021, 11, 25));
            await ModifyCourse("Baseball", new DateTime(2021, 8, 01), new DateTime(2021, 12, 01), "in progress", "Do your best!", "Tad", "(777)777-7777", "teach2@gmail.com", "MidTermTest", new DateTime(2021, 10, 01), "FinalProject", new DateTime(2021, 11, 25));
            await ModifyCourse("Math101", new DateTime(2021, 8, 01), new DateTime(2021, 12, 01), "in progress", "Do your best!", "Barry", "(999)999-9999", "teach4@gmail.com", "MidTermTest", new DateTime(2021, 10, 01), "FinalProject", new DateTime(2021, 11, 25));
        }
        //term functions
        public static async Task AddTerm(string termTitle, DateTime termStartDate, DateTime termEndtDate, int course1, int course2, int course3, int course4, int course5, int course6)
        {
            await Init();
            var Term = new TermClass
            {


                TermTitle = termTitle,
                TermStartDate = termStartDate,
                TermEndtDate = termEndtDate,
                Course1 = course1,
                Course2 = course2,
                Course3 = course3,
                Course4 = course4,
                Course5 = course5,
                Course6 = course6,
            };
            await db.InsertOrReplaceAsync(Term);
    }
        public static async Task DeleteTerm(int id)
        {
            await Init();
            await db.DeleteAsync<TermClass>(id);

        }

        public static async Task<IList<TermClass>> GetTermList()
        {
            await Init();
            var termList = await db.Table<TermClass>().ToListAsync();
            return termList;

        }

        public static async Task<TermClass> GetTerm(int id)
        {
            await Init();
            var term = await db.GetAsync<TermClass>(id);
            return term;
        }

        //course functions
        public static async Task<CourseClass> GetCourse(int id)
        {
            await Init();
            var course = await db.GetAsync<CourseClass>(id);
            return course;
        }
        public static async Task<IList<CourseClass>> GetCourseList()
        {
            await Init();
            var CourseList = await db.Table<CourseClass>().ToListAsync();
            return CourseList;
        }
        public static async Task ModifyCourse(string courseTitle, DateTime courseStartDate, DateTime courseEndtDate, string statusOfCourse, string courseNotes, string instructorName, string instructorPhone, string instructorEmail, string objectiveAssesmentName, DateTime objectiveAssesmentDueDate, string performanceAssesmentName, DateTime performanceAssesmentDueDate)
        {
            await Init();
            var course = new CourseClass
            {
                CourseTitle = courseTitle,
                CourseStartDate = courseStartDate,
                CourseEndtDate = courseEndtDate,
                StatusOfCourse = statusOfCourse,
                CourseNotes = courseNotes,
                InstructorName = instructorName,
                InstructorPhone = instructorPhone,
                InstructorEmail = instructorEmail,
                ObjectiveAssesmentName = objectiveAssesmentName,
                ObjectiveAssesmentDueDate = objectiveAssesmentDueDate,
                PerformanceAssesmentName = performanceAssesmentName,
                PerformanceAssesmentDueDate = performanceAssesmentDueDate,

            };
            await db.InsertOrReplaceAsync(course);
        }

        public static async Task BuildData()
        {
            await Init();
            await AddTerm("Term 1", new DateTime(2021, 8, 01), new DateTime(2021, 12, 01), 0, 1, 2, 3, 4, 5);
            await ModifyCourse("MobileAppDevelopment C971", new DateTime(2021, 8, 01), new DateTime(2021, 12, 01), "in progress", "Do your best!", "Billy Frank Haltom", "(423)782-7613", "bhaltom@wgu.edu", "MidTermTest", new DateTime(2021, 10, 01), "FinalProject", new DateTime(2021, 11, 25));
            await ModifyCourse("History101", new DateTime(2021, 8, 01), new DateTime(2021, 12, 01), "in progress", "Do your best!", "Sarah", "(888)888-8888", "teach3@gmail.com", "MidTermTest", new DateTime(2021, 10, 01), "FinalProject", new DateTime(2021, 11, 25));
            await ModifyCourse("Dancing101", new DateTime(2021, 8, 01), new DateTime(2021, 12, 01), "in progress", "Do your best!", "Jess", "(222)222-2222", "teach5@gmail.com", "MidTermTest", new DateTime(2021, 10, 01), "FinalProject", new DateTime(2021, 11, 25));
            await ModifyCourse("Lit101", new DateTime(2021, 8, 01), new DateTime(2021, 12, 01), "in progress", "Do your best!", "Larry", "(666)666-6666", "teach1@gmail.com", "MidTermTest", new DateTime(2021, 10, 01), "FinalProject", new DateTime(2021, 11, 25));
            await ModifyCourse("Baseball", new DateTime(2021, 8, 01), new DateTime(2021, 12, 01), "in progress", "Do your best!", "Tad", "(777)777-7777", "teach2@gmail.com", "MidTermTest", new DateTime(2021, 10, 01), "FinalProject", new DateTime(2021, 11, 25));
            await ModifyCourse("Math101", new DateTime(2021, 8, 01), new DateTime(2021, 12, 01), "in progress", "Do your best!", "Barry", "(999)999-9999", "teach4@gmail.com", "MidTermTest", new DateTime(2021, 10, 01), "FinalProject", new DateTime(2021, 11, 25));

        }
    }
}
