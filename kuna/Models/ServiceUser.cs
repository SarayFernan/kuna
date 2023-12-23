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
    internal class ServiceUser
    {
        public static UserAccountModel user = null;

        public static UserAccountModel AuthenticateUser(string user , SecureString password)
        {
            UserModel userM = new UserModel();
            userM.Name = user;
            userM.Password = HandleSecureString(password);

            RestClient client = new RestClient("http://localhost:8000/authenticate");
            RestRequest request = new RestRequest("", Method.Post);
            request.RequestFormat = RestSharp.DataFormat.Json;
            request.AddBody(userM);
            return client.Execute<UserAccountModel>(request).Data;
        }
        
        private static string HandleSecureString(SecureString value)
        {
            IntPtr valuePtr = IntPtr.Zero;
            try
            {
                valuePtr = Marshal.SecureStringToGlobalAllocUnicode(value);
                return Marshal.PtrToStringUni(valuePtr);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(valuePtr);
            }
        }
    }




}
