using Gestion_Inventaire.DataAccesLayer;
using Gestion_Inventaire.Views.Pages;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;


namespace Gestion_Inventaire
{
  
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        #region Inotify
        // Obligatoire par l'implémentation de l'interface INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        //Fonction qui gère le lancement de l'événément PropertyChanged
        protected virtual void OnPropertyChanged(string nomPropriete)
        {
            //Vérifie si il y a au moins 1 abonné
            if (this.PropertyChanged != null)
            {
                //Lance l'événement -> tous les abonnés seront notifiés
                this.PropertyChanged(this, new PropertyChangedEventArgs(nomPropriete));
            }
        }
        #endregion
  

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            DAL.ConnectionString = "Server=serverName;Port=port;Database=databaseName;Uid=idUser;Pwd=password";
            MainFrame.Navigate(new LandingPage());
            this.Closing += MainWindow_Closing;
        }

        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }

    }
}
