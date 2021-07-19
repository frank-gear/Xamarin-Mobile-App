using System;
using C971FrankHaltom.Views;
using C971FrankHaltom.Models;
using C971FrankHaltom.Services;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace C971FrankHaltom.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CourseDetailsPage : ContentPage
    {
        public static CourseClass CourseDetails;
        public CourseDetailsPage()
        {
            InitializeComponent();
            OnAppearing();
        }

        protected override void OnAppearing()
        {
            if(TermPage.SelectedCourse == null)
            {
                DisplayAlert("Course Details", " Please Select Course to View", "ok");
            }
            else
            {
                CourseDetails = TermPage.SelectedCourse;
                SetDataview();
            }
        }
        private void SetDataview()
        {
            CourseTitle.Text = CourseDetails.CourseTitle;
            StartDate.Text = CourseDetails.CourseStartDate.ToString();
            EndDate.Text = CourseDetails.CourseEndtDate.ToString();
            StatusOfCourse.Text = CourseDetails.StatusOfCourse;
            Notes.Text = CourseDetails.CourseNotes;
            Instructorname.Text = CourseDetails.InstructorName;
            instructorPhone.Text = CourseDetails.InstructorPhone;
            Instructoremail.Text = CourseDetails.InstructorEmail;
            Objectivename.Text = CourseDetails.ObjectiveAssesmentName;
            ObjectiveDueDate.Text = CourseDetails.ObjectiveAssesmentDueDate.ToString();
            PreformanceName.Text = CourseDetails.PerformanceAssesmentName;
            PreformanceDueDate.Text = CourseDetails.PerformanceAssesmentDueDate.ToString();
        }
        private void ShareNotes_Clicked(object sender, EventArgs e)
        {
            if (emailList.Count > 0)
            {
                ShareNotes message = new ShareNotes();
                //sms.SendSms(currentCourse.Notes, InstructorPhone.Text);
                message.SendEmail("'Student Name' - " + currentCourse.Name + " Notes", currentCourse.Notes, emailList);
                EmailList.Text = "";
            }
            else
            {
                DisplayAlert("No Emails Selected", "Enter email address(es) to send notes to.", "OK");
            }
        }
    }
}