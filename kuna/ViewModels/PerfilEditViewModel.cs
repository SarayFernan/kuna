using kuna.Models;
using kuna.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace kuna.ViewModels
{
    public class PerfilEditViewModel : ViewModelBase
    {
        private string image;
        private string sobreMi;

        //Properties
        public string Image
        {
            get
            {
                return image;
            }

            set
            {
                image = value;
                OnPropertyChanged(nameof(image));
            }
        }

        public string SobreMi
        {
            get
            {
                return sobreMi;
            }

            set
            {
                sobreMi = value;
                OnPropertyChanged(nameof(sobreMi));
            }
        }

        public PerfilEditViewModel()
        {
            Image = ServiceUser.user.ProfilePicture;
            SobreMi = ServiceUser.user.AboutMe;
        }

    
        public void Edit()
        {
            // Obtener los nuevos datos del usuario
            ServiceUser.user.AboutMe = SobreMi;
            ServiceUser.user.ProfilePicture = Image;

            // Llamar al método EditUser para actualizar el usuario
            ServiceUser.EditUser(ServiceUser.user);

            // Volver a la pantalla del perfil
            MainViewModel.mainViewModel.ExecuteShowPerfilViewCommand(null);
        }
    }
}
