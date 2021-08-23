using SQLite;
using C971FrankHaltom.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Plugin.LocalNotifications;

namespace C971FrankHaltom.Services
{
    //public static interface ILocalDataService
    //{
    //    void Initialize();
    //     List<TermClass> GetTerms();
    //    List<CourseClass> GetCourses();
    //    void CreateTerm(TermClass term);

    //    void CreateCourse(CourseClass course);
        
    //    TermClass GetTerm();
    //    void DeleteTerm(TermClass term);
    //    CourseClass GetCourse();
    //    void ModifyCourse(CourseClass course);
    //}
    public static class SqlLiteDatabaseService //: ILocalDataService
    {
        public static SQLiteConnection _database;

        static public void Initialize()
        {
            if (_database == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),  "TTTermApppsDb.db3");
                _database = new SQLiteConnection(dbPath);
                _database.CreateTable<AssessmentClass>();
                _database.CreateTable<CourseClass>();
                _database.CreateTable<TermClass>();
                _database.CreateTable<NotificationClass>();
                
            }
            

            
        }
        static public void CreatePersistantNotification(string title, string body, DateTime date)
        {
            NotificationClass notification = new NotificationClass();
            notification.Title = title;
            notification.Body = body;
            notification.NotifyTime = date;

            _database.Insert(notification);
            CrossLocalNotifications.Current.Show(notification.Title, notification.Body, notification.NoteId, notification.NotifyTime);


        }
        
        static public int GetNotificationId(string title)
        {
            NotificationClass notification = new NotificationClass();
            notification = _database.Table<NotificationClass>().Where(i => i.Title == title).FirstOrDefault();
            int num = notification.NoteId;
            return num;

        }
        static public NotificationClass GetNotification(int id)
        {
            NotificationClass notification = new NotificationClass();
            notification = _database.Table<NotificationClass>().Where(i => i.NoteId == id).FirstOrDefault();
            return notification;
        }
        

            static public void CreateTerm(TermClass term)
        {
            _database.Insert(term);
        }

        static public void DeleteTerm(TermClass term)
        {
            // _database.Execute(query: "DELETE FROM TermClass");
            _database.Delete(term);
        }
        static public int GetCourseId(string name)
        {
            CourseClass course = new CourseClass();
            course = _database.Table<CourseClass>().Where(i => i.CourseTitle == name).FirstOrDefault();
            int num = course.CourseId;
            return num;
        }
        static public int GetAssessId(string name)
        {
            AssessmentClass assessment = new AssessmentClass();
            assessment = _database.Table<AssessmentClass>().Where(i => i.Name == name).FirstOrDefault();
            int num = assessment.AssesmentId;
            return num;
        }
        static public CourseClass GetCourse(int id)
        {
            return _database.Get<CourseClass>(id);
        }
        static public string GetCourseTitle(int id)
        {
            CourseClass course = new CourseClass();
            course = _database.Table<CourseClass>().Where(i => i.CourseId == id).FirstOrDefault();
            return course.CourseTitle;
        }
        static public string GetAssessName(int id)
        {
            AssessmentClass assessment = new AssessmentClass();
            assessment = _database.Table<AssessmentClass>().Where(i => i.AssesmentId == id).FirstOrDefault();
            return assessment.Name;
        }
        static public string GetAssessduedate(int id)
        {
            AssessmentClass assessment = new AssessmentClass();
            assessment = _database.Table<AssessmentClass>().Where(i => i.AssesmentId == id).FirstOrDefault();
            return assessment.DueDate.ToString();
        }
        static public TermClass GetTerm()
        {
            return _database.Table<TermClass>().FirstOrDefault();
        }

        static public void ModifyTerm(TermClass term)
        {
            _database.Update(term);
        }

        static public void ModifyCourse(CourseClass course)
        {
            _database.Update(course);
        }
        static public void ModifyAssessment(AssessmentClass assessment)
        {
            _database.Update(assessment);
        }
        //create terms
        static public void BuildData()
        {
            // create assessments
            int num = _database.Table<AssessmentClass>().Count();
            if (num <= 0)
            {
                CreateAssess(new AssessmentClass("MidTermTest", "Objective", new DateTime(2021, 10, 01)));
                CreateAssess(new AssessmentClass("FinalProject", "Performance", new DateTime(2021, 11, 25)));
            }
            //create classes
            num = _database.Table<CourseClass>().Count();
            if (num <= 0)
            {
                CreateCourse(new CourseClass("MobileAppDevelopment C971", new DateTime(2021, 8, 01), new DateTime(2021, 12, 01), "in progress", "Do your best!", "Billy Frank Haltom", "4237827613", "bhaltom@wgu.edu", GetAssessId("MidTermTest"), GetAssessId("FinalProject")));
                CreateCourse(new CourseClass("History101", new DateTime(2021, 8, 01), new DateTime(2021, 12, 01), "in progress", "Do your best!", "Sarah", "8888888888", "teach3@gmail.com", GetAssessId("MidTermTest"), GetAssessId("FinalProject")));
                CreateCourse(new CourseClass("Dancing101", new DateTime(2021, 8, 01), new DateTime(2021, 12, 01), "in progress", "Do your best!", "Jess", "2222222222", "teach5@gmail.com", GetAssessId("MidTermTest"), GetAssessId("FinalProject")));
                CreateCourse(new CourseClass("Lit101", new DateTime(2021, 8, 01), new DateTime(2021, 12, 01), "in progress", "Do your best!", "Larry", "6666666666", "teach1@gmail.com", GetAssessId("MidTermTest"), GetAssessId("FinalProject")));
                CreateCourse(new CourseClass("Baseball", new DateTime(2021, 8, 01), new DateTime(2021, 12, 01), "in progress", "Do your best!", "Tad", "7777777777", "teach2@gmail.com", GetAssessId("MidTermTest"), GetAssessId("FinalProject")));
                CreateCourse(new CourseClass("Math101", new DateTime(2021, 8, 01), new DateTime(2021, 12, 01), "in progress", "Do your best!", "Barry", "9999999999", "teach4@gmail.com", GetAssessId("MidTermTest"), GetAssessId("FinalProject")));

            }
            //create term
            num = _database.Table<TermClass>().Count();
            if (num <= 0)
            {
                CreateTerm(new TermClass("Term 1", new DateTime(2021, 8, 01), new DateTime(2021, 12, 01), GetCourseId("MobileAppDevelopment C971"), GetCourseId("History101"), GetCourseId("Dancing101"), GetCourseId("Lit101"), GetCourseId("Baseball"), GetCourseId("Math101")));

            }
            //create notifications
            num = _database.Table<NotificationClass>().Count();
            if (num > 0)
            {
                NotificationClass notification = new NotificationClass();
                for (int i = 1; i <= num; i++)
                {
                    notification = GetNotification(i);
                    CrossLocalNotifications.Current.Show(notification.Title, notification.Body, notification.NoteId, notification.NotifyTime);

                }
            }

        }

        static public void CreateCourse(CourseClass course)
        {
            _database.Insert(course);
        }
        static public void CreateAssess(AssessmentClass assessmentClass)
        {
            _database.Insert(assessmentClass);
        }
        static public IList<TermClass> GetTermsList()
        {
            return _database.Table<TermClass>().ToList();
        }

        static public IList<CourseClass> GetCoursesList()
        {
            return _database.Table<CourseClass>().ToList();
        }
        static public IList<AssessmentClass> GetAssessmentsList()
        {
            return _database.Table<AssessmentClass>().ToList();
        }
        static public IList<AssessmentClass> GetObjAssessmentsList()
        {
            return _database.Table<AssessmentClass>().Where(i => i.Type == "Objective").ToList();
        }
        static public IList<AssessmentClass> GetPerAssessmentsList()
        {
            return _database.Table<AssessmentClass>().Where(i => i.Type == "Performance").ToList();
        }
    }


}
