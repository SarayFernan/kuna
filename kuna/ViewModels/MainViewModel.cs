using FontAwesome.Sharp;
using kuna.Models;
using kuna.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace kuna.ViewModels
{
    public class MainViewModel: ViewModelBase
    {
        //private UserAccountModel _curentUserAccount;
        //private ServiceUser userRepository;

        private ViewModelBase currentChildView;
        private String caption;
        private IconChar icon;

        public ViewModelBase CurrentChildView
        {
            get
            {
                return currentChildView;
            }

            set
            {
                currentChildView = value;
                OnPropertyChanged(nameof(currentChildView));//Para actualizar la vista 
            }
        }

        public String Caption
        {
            get
            {
                return caption;
            }

            set
            {
                caption = value;
                OnPropertyChanged(nameof(caption));//Para actualizar la vista 
            }
        }

        public IconChar Icon
        {
            get
            {
                return icon;
            }

            set
            {
                icon = value;
                OnPropertyChanged(nameof(icon));//Para actualizar la vista 
            }
        }

        //Definimos los comandos para la interaccion del user 
        //Para mostrar la vista de inicio
        public ICommand ShowHomeViewCommand { get; }
        public ICommand ShowBuscarViewCommand { get; }
        public ICommand ShowPerfilViewCommand { get; }
        public ICommand ShowInformacionViewCommand { get; }
        public ICommand ShowPostViewCommand { get; }

        public MainViewModel()
        {
            LoadCurrentUserData();

            //Inicializar comandos
            ShowHomeViewCommand = new ViewModelCommand(ExecuteShowHomeViewCommand);
            ShowBuscarViewCommand = new ViewModelCommand(ExecuteShowBuscarViewCommand);
            ShowPerfilViewCommand = new ViewModelCommand(ExecuteShowPerfilViewCommand);
            ShowInformacionViewCommand = new ViewModelCommand(ExecuteShowInformacionViewCommand);
            ShowPostViewCommand = new ViewModelCommand(ExecuteShowPostViewCommand);

            //Vista predeterminada Home
            ExecuteShowHomeViewCommand(null);
        }

        private void ExecuteShowPostViewCommand(object obj)
        {
            CurrentChildView = new PostearViewModel();
            Caption = "Crear post";
            Icon = IconChar.Edit;
        }

        private void LoadCurrentUserData()
        {
            //Para mostrar los datos y usar binding en perfil 
            //1.VAlidar usuario que ya lo tenemos 
            //var isValid = ServiceUser.AuthenticateUser();
            //if (isVAlidUSer){

        }

        private void ExecuteShowInformacionViewCommand(object obj)
        {
            CurrentChildView = new InformaciónView();
            Caption = "Información";
            Icon = IconChar.InfoCircle;
        }

        //PERFIL
        private void ExecuteShowPerfilViewCommand(object obj)
        {
            CurrentChildView = new PerfilViewModel();
            Caption = "Perfil";
            Icon = IconChar.Paw;
        }

        //BUSCAR
        private void ExecuteShowBuscarViewCommand(object obj)
        {
            CurrentChildView = new BuscarViewModel();
            Caption = "Explorar";
            Icon = IconChar.Search;
        }

        //HOME
        private void ExecuteShowHomeViewCommand(object obj)
        {
            CurrentChildView = new HomeViewModel();
            Caption = "Inicio";
            Icon = IconChar.Home;
        }
    }
}
