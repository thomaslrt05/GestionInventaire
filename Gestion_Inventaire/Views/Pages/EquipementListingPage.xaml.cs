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
using Gestion_Inventaire.Views.Windows;
using Type = Gestion_Inventaire.Models.Type;

namespace Gestion_Inventaire.Views.Pages
{
    
    public partial class EquipementListingPage : Page
    {
        public EquipementListingPage()
        {
            InitializeComponent();
            this.DataContext = this;
            LoadDataEquipement();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int id = (int)button.Tag;
            try
            {
                DAL dAL = new DAL();
                dAL.SpecificityFact.DeleteCauseEquipment(id);
                dAL.EquipementFact.Delete(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show("La suppréssion à échoué");
            }
            LoadDataEquipement();
        }

        private void AddEquipement_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new EquipementAddPage());
        }

        private void ShowSpecificity_Button(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int equipementId = (int)button.Tag; 
            List<Specificity> specificities = LoadSpecificities(equipementId);
            SpecificityWindow specificityWindow = new SpecificityWindow(equipementId);
            specificityWindow.SetSpecificities(specificities);
            specificityWindow.ShowDialog();
        }

        private List<Specificity> LoadSpecificities(int equipementId)
        {

            List<Specificity> specificities = new List<Specificity>();
            try
            {
                DAL dAL = new DAL();
                specificities =  dAL.SpecificityFact.GetAllForEquipment(equipementId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur est lors du chargement des specificitées");
            }
            return specificities;
        }


        private void BackToLandingPage_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new LandingPage());
        }

        private void LoadDataEquipement()
        {
            try
            {
                DAL dal = new DAL();
                List<Equipement>? equipements = dal.EquipementFact.GetAll();
                List<EquipementVM> datas = new List<EquipementVM>();
                foreach(Equipement equipement in equipements)
                {
                    Mark? mark = dal.MarkFact.Get(equipement.Mark.Id);
                    Type? type = dal.TypeFact.Get(equipement.Type.Id);
                    datas.Add(new EquipementVM(equipement,mark,type));
                }
                dataGrid.ItemsSource = datas;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur est survenue en chargeant les datas des cours");
            }
        }

        private void ModifyEquipment(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement clickedElement)
            {
               
                if (clickedElement.Tag is int id)
                {

                    
                    NavigationService.Navigate(new EquipementUpdatePage(id));
                }
            }
        }

    }
}

