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
        //PAra encapsular un metodo
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
            //Si es nullo no se ha establecido la validacion
            return _canExecuteAction == null ? true : _canExecuteAction(parameter);//Retonamos el valor del delgado
        }

        public void Execute(object parameter)
        {
            _executeAction(parameter);
        }
    }
}
