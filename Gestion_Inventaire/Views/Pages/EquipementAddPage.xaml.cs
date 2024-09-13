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
using Type = Gestion_Inventaire.Models.Type;

namespace Gestion_Inventaire.Views.Pages
{

    public partial class EquipementAddPage : Page
    {
        public EquipementAddPage()
        {
            InitializeComponent();
            LoadComboBoxMark();
            LoadComboBoxType();
        }

        private void LoadComboBoxMark()
        {

            try
            {
                DAL dal = new DAL();
                List<Mark>? marks = new List<Mark>();
                marks = dal.MarkFact.GetAll();
                markComboBox.ItemsSource = marks;
                markComboBox.DisplayMemberPath = "Name";
                markComboBox.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("La combox se s'est pas chargé");
            }
        }

        private void LoadComboBoxType()
        {

            try
            {
                DAL dal = new DAL();
                List<Type>? types = new List<Type>();
                types = dal.TypeFact.GetAll();
                typeComboBox.ItemsSource = types;
                typeComboBox.DisplayMemberPath = "Name";
                typeComboBox.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("La combox se s'est pas chargé");
            }
        }

        private void CreateEquipement_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DAL dal = new DAL();
                Type selectedType = (Type)typeComboBox.SelectedItem;
                Mark selectedMark = (Mark)markComboBox.SelectedValue;
                string descriptionEquipement = description.Text;
                Equipement equipement = new Equipement(0,descriptionEquipement, selectedType, selectedMark);
                dal.EquipementFact.Save(equipement);
            }
            catch (Exception ex)
            {
                MessageBox.Show("L'équipement n'a pas pu être crée");
            }
            NavigationService?.Navigate(new EquipementListingPage());
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new EquipementListingPage());
        } 
    }
}
