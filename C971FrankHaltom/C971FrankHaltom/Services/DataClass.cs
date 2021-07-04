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
            var databasePath = Path.Combine(Xamarin.Essentials.FileSystem.AppDataDirectory, "TermData.db");
            db = new SQLiteAsyncConnection(databasePath);
            await db.CreateTableAsync<TermClass>();
            await db.CreateTableAsync<CourseClass>();
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

        public static async Task<IEnumerable<TermClass>> GetTermList()
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
        public static async Task<IEnumerable<CourseClass>> GetCourseList()
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
    }
}
