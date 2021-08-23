using System;
using C971FrankHaltom.Views;
using C971FrankHaltom.Models;
using C971FrankHaltom.Services;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using System.Threading.Tasks;

namespace C971FrankHaltom.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CourseDetailsPage : ContentPage
    {
        public static CourseClass CourseDetails = new CourseClass();
        private static List<string> send = new List<string>();
        
        public CourseDetailsPage()
        {
            InitializeComponent();
            OnAppearing();
        }
        public async Task share(string subject, string body, List<string> send)
        {
            var email = new EmailMessage
            {
                Subject = subject,
                Body = body,
                To = send,
            };
            await Email.ComposeAsync(email);
        }
        protected override void OnAppearing()
        {
            if(TermPage.SelectedCourse == null)
            {
                DisplayAlert("Course Details", " Please Select Course to View", "ok");
            }
            else
            {
                CourseDetails = SqlLiteDatabaseService.GetCourse(TermPage.SelectedCourse.CourseId);
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
            Objectivename.Text = SqlLiteDatabaseService.GetAssessName(CourseDetails.ObjectiveId);
            ObjectiveDueDate.Text = SqlLiteDatabaseService.GetAssessduedate(CourseDetails.ObjectiveId);
            PreformanceName.Text = SqlLiteDatabaseService.GetAssessName(CourseDetails.PerformanceId);
            PreformanceDueDate.Text = SqlLiteDatabaseService.GetAssessduedate(CourseDetails.PerformanceId);
        }
        private  void sendemail_Clicked(object sender, EventArgs e)
        {

            if (!EditCoursePage.Mchek(emailshare.Text) || string.IsNullOrWhiteSpace(emailshare.Text))
            {
                 DisplayAlert("endter email", "enter a valid email address to share notes", "OK");
            }
            else
            {
                send.Add(emailshare.Text);
                var Subject = CourseTitle.Text + " Notes";
                var Body = Notes.Text;
                 share(Subject, Body, send);
                
            }
        }
    }
}