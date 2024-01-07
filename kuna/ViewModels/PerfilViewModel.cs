using FontAwesome.Sharp;
using kuna.Models;
using kuna.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace kuna.ViewModels
{
    public class PerfilViewModel : ViewModelBase
    {
        private UserAccountModel user;
        private string nombre;
        private string sobreMi;
        private string imagen;
        private Visibility editar;


        public string Nombre
        {
            get { return nombre; }

            set
            {
                nombre = value;
                OnPropertyChanged(nameof(nombre));
            }
        }

        public string SobreMi
        {
            get { return sobreMi; }

            set
            {
                sobreMi = value;
                OnPropertyChanged(nameof(sobreMi));
            }
        }

        public string Imagen
        {
            get { return imagen; }

            set
            {
                imagen = value;
                OnPropertyChanged(nameof(imagen));
            }
        }

        public Visibility Editar
        {
            get { return editar; }
            set
            {
                editar = value;
                OnPropertyChanged(nameof(editar));
            }
        }

        public UserAccountModel User
        {
            get { return user; }

            set
            {
            }
        }

        public PerfilViewModel(UserAccountModel user)
        {
            if (user == null)
            {
                this.user = ServiceUser.user;
            }
            else
            {
                this.user = user;
            }

            Nombre = this.user.Name;
            SobreMi = this.user.AboutMe;
            Imagen = this.user.ProfilePicture;

            if (this.user.Name.Equals(ServiceUser.user.Name))
            {
                this.Editar = Visibility.Visible;
            }
            else
            {
                this.Editar = Visibility.Hidden;
            }
        }

        //MEtodo para mostrar la visra de edicion de perfil
        public void Edit()
        {
            MainViewModel.mainViewModel.ShowPerfilEditView();
            
        }
         
    }
}
