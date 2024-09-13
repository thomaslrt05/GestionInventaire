using Gestion_Inventaire.DataAccesLayer;
using Gestion_Inventaire.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Gestion_Inventaire.Views.Pages
{
   
    
    public partial class CourseListingPage : Page
    {
        
        public CourseListingPage()
        {
            InitializeComponent();
            this.DataContext = this;
            LoadDataCourse();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int courseId = (int)button.Tag;
            try
            {
                DAL dAL = new DAL();
                dAL.CourseFact.Delete(courseId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur est survenue en suppri");
            }
            LoadDataCourse();
        }

        private void AddCourse_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new CourseAddingPage());
        }

        private void BackToLandingPage_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new LandingPage());
        }

        private void LoadDataCourse()
        {
            try
            {
                DAL dal = new DAL();
                List<Course>? courses = dal.CourseFact.GetAll();
                List<CourseVM> dataList = new List<CourseVM>();
               foreach(Course course in courses)
                {
                    Local local = dal.LocalFact.Get(course.Schedule.Local.Id);
                    dataList.Add(new CourseVM(course,local));
                }
                dataGrid.ItemsSource = dataList;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Une erreur est survenue en chargeant les datas des cours");
            }
        }
    }
}
