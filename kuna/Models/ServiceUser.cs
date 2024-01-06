using kuna.Model;
using Microsoft.Data.SqlClient;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace kuna.Models
{
    public class ServiceUser
    {
        public static UserAccountModel user = null;


        //Metodo para utenticar que el usuario que introduce es correcto.
        public static UserAccountModel AuthenticateUser(string user , SecureString password)
        {
            UserModel userM = new UserModel();
            userM.Name = user;
            userM.Password = HandleSecureString(password);

            RestClient client = new RestClient("http://localhost:8000/authenticate");
            RestRequest request = new RestRequest("", Method.Post);
            request.RequestFormat = RestSharp.DataFormat.Json;
            //La instancia de UserModel (userM) se agrega como el cuerpo de la solicitud.
            request.AddBody(userM);
            //La propiedad Data de la respuesta se devuelve como resultado de la función.
            return client.Execute<UserAccountModel>(request).Data;
        }



        //Este metodo convierte un objeto SecureString en una cadena de texto. 
        private static string HandleSecureString(SecureString value)
        {
            //puntero
            IntPtr valuePtr = IntPtr.Zero;
            try
            {
                valuePtr = Marshal.SecureStringToGlobalAllocUnicode(value);
                return Marshal.PtrToStringUni(valuePtr);
            }
            finally
            {
                //para evitar posibles fugas de memoria.
                Marshal.ZeroFreeGlobalAllocUnicode(valuePtr);
            }
        }

        public static UserAccountModel EditUser(UserAccountModel updatedUser)
        {
            RestClient client = new RestClient("http://localhost:8000/useraccount");
            RestRequest request = new RestRequest("", Method.Put);
            request.RequestFormat = RestSharp.DataFormat.Json;

            request.AddBody(updatedUser);

            // es una interfaz en la biblioteca RestSharp que representa la respuesta recibida
            // después de realizar una solicitud HTTP a través de la librería.
            return client.Execute<UserAccountModel>(request).Data;

        }


        //metodo para eliminar usuarios
        public static void DeleteUser(string userName)
        {
            string url = "http://localhost:8000/users/" + userName;
            RestClient client = new RestClient(url);
            RestRequest request = new RestRequest("", Method.Delete);
            client.Execute(request);
        }


        //metodo para recoger usuario
        public static UserAccountModel GetUserAccount(string userName)
        {
            string url = "http://localhost:8000/useraccount/" + userName;
            RestClient client = new RestClient(url);
            RestRequest request = new RestRequest("", Method.Get);
            return client.Execute<UserAccountModel>(request).Data;
        }
    }


}
