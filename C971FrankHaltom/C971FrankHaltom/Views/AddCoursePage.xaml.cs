using System;
using C971FrankHaltom.Views;
using C971FrankHaltom.Models;
using C971FrankHaltom.Services;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.LocalNotifications;

namespace C971FrankHaltom.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddCoursePage : ContentPage
    {
        public static List<AssessmentClass> performanceassessments = (List<AssessmentClass>)SqlLiteDatabaseService.GetPerAssessmentsList();
        public static List<AssessmentClass> objectiveeassessments = (List<AssessmentClass>)SqlLiteDatabaseService.GetObjAssessmentsList();
        public AddCoursePage()
        {
            InitializeComponent();
            OnAppearing();
        }
        bool mchek(string x)
        {
            try
            {
                var chk = new System.Net.Mail.MailAddress(x);
                return chk.Address == x;
            }
            catch
            {
                return false;
            }
        }
        protected override void OnAppearing()
        {
            performanceassessments.Clear();
            objectiveeassessments.Clear();
            performanceassessments = (List<AssessmentClass>)SqlLiteDatabaseService.GetPerAssessmentsList();
            objectiveeassessments = (List<AssessmentClass>)SqlLiteDatabaseService.GetObjAssessmentsList();
            PerformancePicker.ItemsSource = performanceassessments;
            ObjectivePicker.ItemsSource = objectiveeassessments;
            PerformancePicker.ItemDisplayBinding = new Binding("Name");
            ObjectivePicker.ItemDisplayBinding = new Binding("Name");
        }

        private void SaveBtn_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CourseTitle.Text) || string.IsNullOrWhiteSpace(Instructorname.Text) || string.IsNullOrWhiteSpace(Instructoremail.Text)
                || string.IsNullOrWhiteSpace(instructorPhone.Text))
            {
                DisplayAlert("Course Edit", " Please Select fill in all sections", "ok");
            }
            else if (StartDate.Date > EndDate.Date)
            {
                DisplayAlert("Course Edit", " Course start date must come before the end date", "ok");
            }
            else if (PerformancePicker.SelectedIndex == -1 || ObjectivePicker.SelectedIndex == -1 || CourseStatus.SelectedIndex == -1)
            {
                DisplayAlert("Course Edit", " Please select your assessments and or course status", "ok");
            }
            else if (instructorPhone.Text.Any(x => char.IsLetter(x)))
            {
                DisplayAlert("Course Edit", " Please only enter numbers for instructor phone number", "ok");
            }
            else if (instructorPhone.Text.Length != 7 && instructorPhone.Text.Length != 10)
            {
                DisplayAlert("Course Edit", " Phone number should  be 7 or 10 digits long", "ok");
            }
            else if (!mchek(Instructoremail.Text))
            {
                DisplayAlert("Course Edit", " Email is not valid", "ok");
            }
            else
            {
                if (StartSwitch.IsToggled)
                {
                    CrossLocalNotifications.Current.Show(CourseTitle.Text, "Start Date", 101, StartDate.Date);
                }
                if (endSwitch.IsToggled)
                {
                    CrossLocalNotifications.Current.Show(CourseTitle.Text, "End Date", 101, EndDate.Date);
                }
                if (ObjectivetSwitch.IsToggled)
                {
                    CrossLocalNotifications.Current.Show(objectiveeassessments[ObjectivePicker.SelectedIndex].Name, "Due Date", 101, objectiveeassessments[ObjectivePicker.SelectedIndex].DueDate);
                }
                if (PreformanceSwitch.IsToggled)
                {
                    CrossLocalNotifications.Current.Show(performanceassessments[PerformancePicker.SelectedIndex].Name, "Due Date", 101, performanceassessments[PerformancePicker.SelectedIndex].DueDate);
                }
                CourseClass course = new CourseClass();               
                course.CourseTitle = CourseTitle.Text;
                course.CourseStartDate = StartDate.Date;
                course.CourseEndtDate = EndDate.Date;
                course.CourseNotes = Notes.Text;
                course.InstructorName = Instructorname.Text;
                course.InstructorPhone = instructorPhone.Text;
                course.InstructorEmail = Instructoremail.Text;
                //error being caused becuse slector index has not changed need new catch
                course.StatusOfCourse = CourseStatus.SelectedItem.ToString();
                course.PerformanceId = performanceassessments[PerformancePicker.SelectedIndex].AssesmentId;
                course.PerformanceId = objectiveeassessments[ObjectivePicker.SelectedIndex].AssesmentId;
                SqlLiteDatabaseService.CreateCourse(course);
                DisplayAlert("Course Add", " Course add successfully Please return to the MainPage", "ok");
            }

        }
    }
}