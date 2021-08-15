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
    public partial class EditCoursePage : ContentPage
    {
        public EditCoursePage()
        {
            InitializeComponent();
            OnAppearing();
           
        }

        





        protected override void OnAppearing()
        {
            if (TermPage.SelectedCourse == null)
            {
                DisplayAlert("Course Edit", " Please Select Course to edit", "ok");
            }
            else
            {
                CourseTitle.Placeholder = TermPage.SelectedCourse.CourseTitle;
                StartDate.Date = TermPage.SelectedCourse.CourseStartDate;
                EndDate.Date = TermPage.SelectedCourse.CourseEndtDate;
                Notes.Placeholder = TermPage.SelectedCourse.CourseNotes;
                Instructorname.Placeholder = TermPage.SelectedCourse.InstructorName;
                instructorPhone.Placeholder = TermPage.SelectedCourse.InstructorPhone;
                Instructoremail.Placeholder = TermPage.SelectedCourse.InstructorEmail;
                Objectivename.Placeholder = TermPage.SelectedCourse.ObjectiveAssesmentName;
                ObjectiveDueDate.Date = TermPage.SelectedCourse.ObjectiveAssesmentDueDate;
                PreformanceName.Placeholder = TermPage.SelectedCourse.PerformanceAssesmentName;
                PreformanceDueDate.Date = TermPage.SelectedCourse.PerformanceAssesmentDueDate;
            }
        }

        private void SaveBtn_Clicked(object sender, EventArgs e)
        {

            if(CourseTitle.Text == null || Instructorname.Text == null || Instructoremail.Text == null
                || instructorPhone.Text == null || Objectivename.Text == null || PreformanceName.Text == null)
            {
                DisplayAlert("Course Edit", " Please Select fill in all sections", "ok");
            }
            else
            {
                if (StartSwitch.IsToggled)
                {
                    CrossLocalNotifications.Current.Show("CourseTitle.Text", "Start Date", 101, StartDate.Date);
                }
                if (endSwitch.IsToggled)
                {
                    CrossLocalNotifications.Current.Show("CourseTitle.Text", "End Date", 101, EndDate.Date);
                }
                if (StartSwitch.IsToggled)
                {
                    CrossLocalNotifications.Current.Show("Objectivename.Text", "Due Date", 101, ObjectiveDueDate.Date);
                }
                if (StartSwitch.IsToggled)
                {
                    CrossLocalNotifications.Current.Show("PreformanceName.Text", "Due Date", 101, PreformanceDueDate.Date);
                }
                CourseClass course;
                course = TermPage.SelectedCourse;
                course.CourseTitle = CourseTitle.Text;
                course.CourseStartDate = StartDate.Date;
                course.CourseEndtDate = EndDate.Date;
                course.CourseNotes = Notes.Text;
                course.InstructorName = Instructorname.Text;
                course.InstructorPhone = instructorPhone.Text;
                course.InstructorEmail = Instructoremail.Text;
                course.StatusOfCourse = CourseStatus.SelectedItem.ToString();
                course.ObjectiveAssesmentName = Objectivename.Text;
                course.ObjectiveAssesmentDueDate = ObjectiveDueDate.Date;
                course.PerformanceAssesmentName = PreformanceName.Text;
                course.PerformanceAssesmentDueDate = PreformanceDueDate.Date;
                SqlLiteDatabaseService.ModifyCourse(course);
            }
            


        }
    }
}