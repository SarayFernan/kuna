using kuna.Model;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace kuna.ViewModel
{
    internal class LoginViewModel : ViewModelBase
    {

        //Atributos
        private string username;
        private SecureString password;
        private string errorMessage;
        private bool isViewVisible = true;



        //Properties
        public string Username
        {
            get
            {
                return username;

            }

            set
            {
                username = value;
                OnPropertyChanged(nameof(username));
            }
        }
        public SecureString Password 
        { 
            get
            {
                return password;
            }

            set
            {
                password = value; 
                OnPropertyChanged(nameof(password));
            }
        }
        public string ErrorMessage 
        { 
            get
            {
                return errorMessage;
            }

            set
            {
                errorMessage = value;
                OnPropertyChanged(nameof(errorMessage));
            }
        }
        public bool IsViewVisible 
        {
            get
            {
                return isViewVisible;
            }

            set
            {
                isViewVisible = value;
                OnPropertyChanged(nameof(isViewVisible));
            }
        }

        //Comandos
        public ICommand LoginCommand { get; }
        public ICommand RecoverPasswordCommand { get; }
        public ICommand ShowPasswordCommand { get; }
        public ICommand RememberPasswordCommand { get; }


        public LoginViewModel()
        {
            
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand , CanExecuteLoginCommand);
            RecoverPasswordCommand = new ViewModelCommand(p => ExecuteRecoverPassComand("", ""));
        }

       

        //Validar los datos del login
        private bool CanExecuteLoginCommand(object obj)
        {
            bool validData;

            if (string.IsNullOrWhiteSpace(username) || username.Length < 3 ||
                Password == null || Password.Length < 3)
                validData = false;
            else
                validData = true;
            
            return validData;
        }

       
        private void ExecuteLoginCommand(object obj)
        {
           /* var isValidUser = userRepository.AuthenticateUser(new NetworkCredential(Username, Password));
            if (isValidUser)
            {
                Thread.CurrentPrincipal = new GenericPrincipal(
                    new GenericIdentity(Username), null);
                IsViewVisible = false;
            }
            else
            {
                ErrorMessage = "* Invalid username or password";
            }*/
        }

        private void ExecuteRecoverPassComand(string username , string email)
        {
            throw new NotImplementedException();
        }
    }
}
