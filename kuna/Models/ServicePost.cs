using kuna.Model;
using Microsoft.VisualBasic.ApplicationServices;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kuna.Models
{
    internal class ServicePost
    {
        public static List<PostModel> GetPosts()
        {
            RestClient client = new RestClient("http://localhost:8000/posts");
            RestRequest request = new RestRequest("", Method.Get);
            var response = client.Execute<List<PostModel>>(request);
            return response.Data;
        }

        public static void Post(string nombre, string especie, int edad, string imagen, string tamanio, string raza, string color, string caracteristicas)
        {
            // Si la id da problemas poner un string vacio o un string con un 0
            PostModel postM = new PostModel("", nombre, especie, edad, imagen, tamanio, raza, color, caracteristicas, DateTime.Now, ServiceUser.user.Name);

            RestClient client = new RestClient("http://localhost:8000/posts");
            RestRequest request = new RestRequest("", Method.Post);
            request.RequestFormat = RestSharp.DataFormat.Json;
            request.AddBody(postM);
            client.Execute(request);
        }

        public static void DeletePost(string id)
        {
            string url = "http://localhost:8000/posts/" + id;
            RestClient client = new RestClient(url);
            RestRequest request = new RestRequest("", Method.Delete);
            client.Execute(request);
        }
    }
}
