using Gestion_Inventaire.DataAccesLayer;
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
using System.Windows.Shapes;

namespace Gestion_Inventaire.Views.Windows
{
    
    public partial class SpecAdd : Window
    {
        private int equipmentId;
        public SpecAdd(int equipmentId)
        {
            InitializeComponent();
            this.equipmentId = equipmentId;
        }

        private void CreateSpecificityButton_Click(object sender, RoutedEventArgs e)
        {
            string specificityName = specificityNameTextBox.Text;

            
            if (string.IsNullOrWhiteSpace(specificityName))
            {
                MessageBox.Show("Veuillez entrer un nom de spécificité valide.", "Erreur");
                return;
            }
            try
            {
                DAL dAL = new DAL();
                dAL.SpecificityFact.Create(specificityName,equipmentId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur est survenue en créant la spécificité");
            }


            Close();
        }
    }
}
