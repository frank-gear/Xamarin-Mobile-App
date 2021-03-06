using C971FrankHaltom.Models;
using System.Threading.Tasks;
using C971FrankHaltom.Services;
using C971FrankHaltom.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace C971FrankHaltom
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
       static public int SelectedTerm;
        static public int SelectedCourse;
        static public TermClass Term;
        
        public AppShell()
        {
            SqlLiteDatabaseService.Initialize();
            SqlLiteDatabaseService.BuildData();
            InitializeComponent();
            



            

            //create routes to pages
            Routing.RegisterRoute(nameof(TermPage), typeof(TermPage));
            Routing.RegisterRoute(nameof(AddTermPage), typeof(AddTermPage));            
            Routing.RegisterRoute(nameof(TermDetailPage), typeof(TermDetailPage));
            Routing.RegisterRoute(nameof(EditTermPage), typeof(EditTermPage));
            Routing.RegisterRoute(nameof(CourseDetailsPage), typeof(CourseDetailsPage));
            Routing.RegisterRoute(nameof(EditAssessmentPage), typeof(EditAssessmentPage));
            Routing.RegisterRoute(nameof(EditCoursePage), typeof(EditCoursePage));
            Routing.RegisterRoute(nameof(AddAssessmentPage), typeof(AddAssessmentPage));
            Routing.RegisterRoute(nameof(AddCoursePage), typeof(AddCoursePage));



        }

       
    }
}
