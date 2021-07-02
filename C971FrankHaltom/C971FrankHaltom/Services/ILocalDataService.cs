using SQLite;
using C971FrankHaltom.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace C971FrankHaltom.Services
{
    public interface ILocalDataService
    {
        void Initialize();
         List<TermClass> GetTerms();
        List<CourseClass> GetCourses();
        void CreateTerm(TermClass term);

        void CreateCourse(CourseClass course);
        
        TermClass GetTerm();
        void DeleteTerm(TermClass term);
        CourseClass GetCourse();
        void ModifyCourse(CourseClass course);
    }
    public class SqlLiteDatabaseService : ILocalDataService
    {
        public SQLiteConnection _database;

        public void Initialize()
        {
            if (_database == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),  "TermsAppDb.db3");
                _database = new SQLiteConnection(dbPath);
            }
            _database.CreateTable<CourseClass>();
            _database.CreateTable<TermClass>();

            
        }

        public void CreateTerm(TermClass term)
        {
            _database.Insert(term);
        }

        public void DeleteTerm(TermClass term)
        {
            _database.Execute(query: "DELETE FROM TermClass");
        }

        public CourseClass GetCourse()
        {
            return _database.Table<CourseClass>().FirstOrDefault();
        }

        public TermClass GetTerm()
        {
            return _database.Table<TermClass>().FirstOrDefault();
        }

        public void ModifyCourse(CourseClass course)
        {
            _database.Update(course);
        }
        //create terms
        public void BuildData()
        {
            //create terms
            CreateTerm(new TermClass("Term 1", new DateTime(2021, 8, 01), new DateTime(2021, 12, 01), 0, 1, 2, 3, 4, 5));
            //CreateTerm(new TermClass("Term 2", new DateTime(2021, 12, 01), new DateTime(2022, 03, 01), 6, 7, 8, 9, 10, 11));

            //create classes
            CreateCourse(new CourseClass("MobileAppDevelopment C971", new DateTime(2021, 8, 01), new DateTime(2021, 12, 01), "in progress","Do your best!", "Billy Frank Haltom", "(423)782-7613", "bhaltom@wgu.edu", "MidTermTest", new DateTime(2021, 10, 01), "FinalProject", new DateTime(2021, 11, 25)));
            CreateCourse(new CourseClass("History101", new DateTime(2021, 8, 01), new DateTime(2021, 12, 01), "in progress", "Do your best!", "Sarah", "(888)888-8888", "teach3@gmail.com", "MidTermTest", new DateTime(2021, 10, 01), "FinalProject", new DateTime(2021, 11, 25)));
            CreateCourse(new CourseClass("Dancing101", new DateTime(2021, 8, 01), new DateTime(2021, 12, 01), "in progress", "Do your best!", "Jess", "(222)222-2222", "teach5@gmail.com", "MidTermTest", new DateTime(2021, 10, 01), "FinalProject", new DateTime(2021, 11, 25)));
            CreateCourse(new CourseClass("Lit101", new DateTime(2021, 8, 01), new DateTime(2021, 12, 01), "in progress", "Do your best!", "Larry", "(666)666-6666", "teach1@gmail.com", "MidTermTest", new DateTime(2021, 10, 01), "FinalProject", new DateTime(2021, 11, 25)));
            CreateCourse(new CourseClass("Baseball", new DateTime(2021, 8, 01), new DateTime(2021, 12, 01), "in progress", "Do your best!", "Tad", "(777)777-7777", "teach2@gmail.com", "MidTermTest", new DateTime(2021, 10, 01), "FinalProject", new DateTime(2021, 11, 25)));
            CreateCourse(new CourseClass("Math101", new DateTime(2021, 8, 01), new DateTime(2021, 12, 01), "in progress", "Do your best!", "Barry", "(999)999-9999", "teach4@gmail.com", "MidTermTest", new DateTime(2021, 10, 01), "FinalProject", new DateTime(2021, 11, 25)));
            
            
            //CreateCourse(new CourseClass("MobileAppDevelopment C971", new DateTime(2021, 8, 01), new DateTime(2021, 12, 01), "in progress", "Do your best!", "Billy Frank Haltom", "(423)782-7613", "bhaltom@wgu.edu", "MidTermTest", new DateTime(2021, 10, 01), "FinalProject", new DateTime(2021, 11, 25)));
            //CreateCourse(new CourseClass("MobileAppDevelopment C971", new DateTime(2021, 8, 01), new DateTime(2021, 12, 01), "in progress", "Do your best!", "Billy Frank Haltom", "(423)782-7613", "bhaltom@wgu.edu", "MidTermTest", new DateTime(2021, 10, 01), "FinalProject", new DateTime(2021, 11, 25)));
            //CreateCourse(new CourseClass("MobileAppDevelopment C971", new DateTime(2021, 8, 01), new DateTime(2021, 12, 01), "in progress", "Do your best!", "Billy Frank Haltom", "(423)782-7613", "bhaltom@wgu.edu", "MidTermTest", new DateTime(2021, 10, 01), "FinalProject", new DateTime(2021, 11, 25)));
            //CreateCourse(new CourseClass("MobileAppDevelopment C971", new DateTime(2021, 8, 01), new DateTime(2021, 12, 01), "in progress", "Do your best!", "Billy Frank Haltom", "(423)782-7613", "bhaltom@wgu.edu", "MidTermTest", new DateTime(2021, 10, 01), "FinalProject", new DateTime(2021, 11, 25)));
            //CreateCourse(new CourseClass("MobileAppDevelopment C971", new DateTime(2021, 8, 01), new DateTime(2021, 12, 01), "in progress", "Do your best!", "Billy Frank Haltom", "(423)782-7613", "bhaltom@wgu.edu", "MidTermTest", new DateTime(2021, 10, 01), "FinalProject", new DateTime(2021, 11, 25)));
            //CreateCourse(new CourseClass("MobileAppDevelopment C971", new DateTime(2021, 8, 01), new DateTime(2021, 12, 01), "in progress", "Do your best!", "Billy Frank Haltom", "(423)782-7613", "bhaltom@wgu.edu", "MidTermTest", new DateTime(2021, 10, 01), "FinalProject", new DateTime(2021, 11, 25)));

        }

        public void CreateCourse(CourseClass course)
        {
            _database.Insert(course);
        }

        public List<TermClass> GetTerms()
        {
            return _database.Table<TermClass>().ToList();
        }

        public List<CourseClass> GetCourses()
        {
            return _database.Table<CourseClass>().ToList();
        }
    }


}
