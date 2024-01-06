using FontAwesome.Sharp;
using kuna.Models;
using kuna.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace kuna.ViewModels
{
    public class PerfilViewModel : ViewModelBase
    {

        public string nombre;
        public string sobreMi;

        private ViewModelBase currentChildView;
        private String caption;
        private IconChar icon;

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

        //MEtodo para mostrar la visra de edicion de perfil
        public void Edit()
        {
            MainViewModel.mainViewModel.ShowPerfilEditView();
            
        }
         
    }
}
