using Gestion_Inventaire.DataAccesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Gestion_Inventaire.Models;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Gestion_Inventaire.Views.Pages
{
    /// <summary>
    /// Logique d'interaction pour CourseAddingPage.xaml
    /// </summary>
    public partial class CourseAddingPage : Page
    {
        private bool isHoraireValide = false;
        public CourseAddingPage()
        {
            InitializeComponent();
            LoadComboBoxLocal();
            LoadComboBoxTeacher();
        }

        private void LoadComboBoxLocal()
        {
            
            try
            {
                DAL dal = new DAL();
                List<Local>? locals = new List<Local>();
                locals = dal.LocalFact.GetAll();
                localComboBox.ItemsSource = locals;
                localComboBox.DisplayMemberPath = "Number";
                localComboBox.SelectedIndex = 0;
            }
            catch(Exception ex)
            {
                MessageBox.Show("La combox se s'est pas chargé");
            }
        }

        private void LoadComboBoxTeacher()
        {
            List<Teacher>? teachers = new List<Teacher>();
            try
            {
                DAL dal = new DAL();
                teachers = dal.TeacherFact.GetAll();
                professeurComboBox.ItemsSource = teachers;
                professeurComboBox.DisplayMemberPath = "Name";
            }
            catch (Exception ex)
            {
                MessageBox.Show("La combox se s'est pas chargé");
            }
        }

        private void ValiderHoraire_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DAL dal = new DAL();
                DateTime selectedDate = datePicker.SelectedDate ?? DateTime.MinValue;
                Local selectedLocal = (Local)localComboBox.SelectedItem;
                int selectedLocalId = selectedLocal.Id;
                dal.ScheduleFact.Create(selectedDate, selectedLocalId);
                isHoraireValide = true;
                createSchedulePanel.Visibility = Visibility.Collapsed;
                createCoursePanel.Visibility = Visibility.Visible;
            }
            catch(Exception ex) 
            {
                MessageBox.Show("L'horaire n'a pas pu être crée");
            }

            
        }

        private void ValiderCours_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DAL dal = new DAL();
                int scheduleId = dal.ScheduleFact.GetLastId();
                string enteredText = nameTextBox.Text;
                Teacher selectedTeacher = (Teacher)professeurComboBox.SelectedItem;
                int selectedTeacherId = selectedTeacher.Id;

                dal.CourseFact.Create(enteredText, selectedTeacherId, scheduleId);

                NavigationService?.Navigate(new CourseListingPage());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Le cours n'a pas pu être crée");
            }
        }


        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new CourseListingPage());
        }
    }
}
