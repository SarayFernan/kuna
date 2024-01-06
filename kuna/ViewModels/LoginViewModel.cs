using kuna.Models;
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

        // Comandos para la interfaz de usuario (UI)
        public ICommand LoginCommand { get; }
        public ICommand RecoverPasswordCommand { get; }
        public ICommand ShowPasswordCommand { get; }
        public ICommand RememberPasswordCommand { get; }

        //Constructor
        public LoginViewModel()
        {
            // LoginCommand: comando para el botón de inicio de sesión
            // RecoverPasswordCommand: comando para la recuperación de contraseña (aún sin implementar)
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand , CanExecuteLoginCommand);
            RecoverPasswordCommand = new ViewModelCommand(p => ExecuteRecoverPassComand("", ""));
        }

        // Método asociado al comando de inicio de sesión
        public bool Login()
        {
            // Autentica al usuario utilizando el servicio
            UserAccountModel userAccount = ServiceUser.AuthenticateUser(Username, Password);

            // Verifica si la autenticación fue exitosa
            if (userAccount == null)
            {
                ErrorMessage = "Usuario o contraseña incorrecto";
            }
            else
            {
                // Almacena la información del usuario autenticado en el servicio
                ServiceUser.user = userAccount;
            }

            // Retorna true si la autenticación fue exitosa, de lo contrario false
            return userAccount != null;
        }


        // Método para validar si los datos de inicio de sesión son válidos antes de ejecutar el comando
        private bool CanExecuteLoginCommand(object obj)
        {
            bool validData;

            // Verifica que el nombre de usuario y la contraseña sean válidos
            if (string.IsNullOrWhiteSpace(Username) || Username.Length < 3 ||
                Password == null || Password.Length < 3)
                validData = false;
            else
                validData = true;

            // Retorna true si los datos son válidos, de lo contrario false
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
