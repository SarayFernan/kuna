using kuna.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kuna.ViewModel
{

    //Es abstracta para que solo se pueda usar por herencia 
    public abstract class ViewModelBase : INotifyPropertyChanged
    {

        
        public event PropertyChangedEventHandler PropertyChanged;


        //Evento de que una porpiedad ha cambiado
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
