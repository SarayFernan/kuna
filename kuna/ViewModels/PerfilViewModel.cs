using kuna.Models;
using kuna.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kuna.ViewModels
{
    public class PerfilViewModel : ViewModelBase
    {

        public string nombre;
        public string sobreMi;

        public string Nombre
        {
            get { return nombre; }

            set
            {
                nombre = ServiceUser.username;
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

         
    }
}
