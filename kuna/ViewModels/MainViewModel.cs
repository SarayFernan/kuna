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
        public static MainViewModel mainViewModel;

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
            mainViewModel = this;
            // Comandos para mostrar vistas específicas en la interfaz de usuario
            ShowHomeViewCommand = new ViewModelCommand(ExecuteShowHomeViewCommand);
            ShowBuscarViewCommand = new ViewModelCommand(ExecuteShowBuscarViewCommand);
            ShowPerfilViewCommand = new ViewModelCommand(ExecuteShowPerfilViewCommand);
            ShowInformacionViewCommand = new ViewModelCommand(ExecuteShowInformacionViewCommand);
            ShowPostViewCommand = new ViewModelCommand(ExecuteShowPostViewCommand);

            // Mostrar la vista de inicio al inicializar
            ExecuteShowHomeViewCommand(null);
        }

        private void ExecuteShowPostViewCommand(object obj)
        {
            CurrentChildView = new PostearViewModel();
            Caption = "Crear post";
            Icon = IconChar.Edit;
        }

        private void ExecuteShowInformacionViewCommand(object obj)
        {
            CurrentChildView = new InformacionView();
            Caption = "Información";
            Icon = IconChar.InfoCircle;
        }

        //PERFIL
        public void ExecuteShowPerfilViewCommand(object obj)
        {
            CurrentChildView = new PerfilViewModel((UserAccountModel)obj);
            Caption = "Perfil";
            Icon = IconChar.Paw;
            MainWindow.window.ActualizarBotonesMostrarPerfil();
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

        //EDIT PERFIL
        public void ShowPerfilEditView()
        {
            CurrentChildView = new PerfilEditViewModel();
            Caption = "Editar Perfil";
        }
    }
}
