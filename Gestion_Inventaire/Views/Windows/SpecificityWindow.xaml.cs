using Gestion_Inventaire.DataAccesLayer;
using Gestion_Inventaire.Models;
using Gestion_Inventaire.Views.Pages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Gestion_Inventaire.Views.Windows
{
   
    public partial class SpecificityWindow : Window
    {
        private int idEquipment;
        public SpecificityWindow(int idEquip)
        {
            InitializeComponent();
            idEquipment = idEquip;
        }

        public void SetSpecificities(List<Specificity> specificities)
        {
            dataGrid.ItemsSource = specificities;
        }

        private void AddSpec_Click(object sender, RoutedEventArgs e)
        {
            SpecAdd specAddWindow = new SpecAdd(idEquipment);
            specAddWindow.ShowDialog();
            this.Close();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int id = (int)button.Tag;
            try
            {
                DAL dAL = new DAL();
                dAL.SpecificityFact.Delete(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur est survenue en suppri");
            }
            
        }

    }
}
