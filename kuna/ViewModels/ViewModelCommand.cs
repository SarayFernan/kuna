using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace kuna.ViewModel
{
    public class ViewModelCommand : ICommand
    {
        //Fields 
        //PAra encapsular un metodo , para pasar un metodo como parametro
        private readonly Action<object> _executeAction;
        //Para ver si se puede ejectar su comando 
        private readonly Predicate<object> _canExecuteAction;
        private Action<object> value;

        //Constructors
        public ViewModelCommand(Action<object> executeAction)
        {
            _executeAction = executeAction;
            _canExecuteAction = null;
        }


        public ViewModelCommand(Action<object> executeAction, Predicate<object> canExecuteAction)
        {
            _executeAction = executeAction;
            _canExecuteAction = canExecuteAction;
        }

        //Eventos
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        //Methods
        public bool CanExecute(object parameter)
        {
            //Si es nullo retornamos verdadero ya que no se ha establecido la validacion  si no pasamos el valor del retornado
            return _canExecuteAction == null ? true : _canExecuteAction(parameter);//Retonamos el valor del delgado
        }

        //Ejecuta el metdo que se va a delegar 
        public void Execute(object parameter)
        {
            _executeAction(parameter);
        }
    }
}
