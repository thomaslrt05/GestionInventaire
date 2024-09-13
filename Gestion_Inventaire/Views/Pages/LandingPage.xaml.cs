using GameOn.ViewModels;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Input;


namespace Gestion_Inventaire.Views.Pages
{
    /// <summary>
    /// Logique d'interaction pour LandingPage.xaml
    /// </summary>
    public partial class LandingPage : Page, INotifyPropertyChanged
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

        public LandingPage()
        {
            InitializeComponent();
            this.DataContext = this;
            this.CoursePage = new RelayCommand(ExecuteCoursePage, CanExecute);
            this.EquipementPage = new RelayCommand(ExecuteEquipementPage, CanExecute);
        }

        private bool CanExecute(object parameter)
        {
            return true;
        }

        public ICommand CoursePage { get; private set; }
        public ICommand EquipementPage { get; private set; }

        private void ExecuteCoursePage(object parameter)
        {
            NavigationService?.Navigate(new CourseListingPage());
        }

        private void ExecuteEquipementPage(object parameter)
        {
            NavigationService?.Navigate(new EquipementListingPage());
        }
    }
}
