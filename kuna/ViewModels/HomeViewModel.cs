using kuna.Models;
using kuna.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace kuna.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private string especie;
        private int edad;
        private string tamanio;
        private string color;

        private List<PostModel> posts;

        public string Especie
        {
            get { return especie; }

            set
            {
                especie = value;
                OnPropertyChanged(nameof(especie));
            }
        }
        public int Edad
        {
            get { return edad; }

            set
            {
                edad = value;
                OnPropertyChanged(nameof(edad));
            }
        }
        public string Tamanio
        {
            get { return tamanio; }

            set
            {
                tamanio = value;
                OnPropertyChanged(nameof(tamanio));
            }
        }
        public string Color
        {
            get { return color; }

            set
            {
                color = value;
                OnPropertyChanged(nameof(color));
            }
        }

        public void CargarPosts()
        {
            posts = ServicePost.GetPosts();
        }

        public List<PostModel> GetPosts()
        {
            if (posts == null)
            {
                CargarPosts();
            }

            return posts;
        }

        public HomeViewModel()
        {
            Especie = "Todas";
            Tamanio = "Cualquiera";
            Color = "";
        }

        public List<PostModel> GetPostsFiltrados()
        {
            List<PostModel> filtrados = new List<PostModel>();

            foreach (PostModel post in posts)
            {
                if ((Especie.Equals("Todas") || post.Species.Equals(Especie))
                    && ((post.Age >= Edad - 2) && (post.Age <= Edad + 2))
                    && (Tamanio.Equals("Cualquiera") || post.Size.Equals(Tamanio))
                    && post.Color.IndexOf(Color, StringComparison.OrdinalIgnoreCase) >= 0) // equivalente a un supuesto método containsIgnoreCase
                {
                    filtrados.Add(post);
                }
            }

            return filtrados;
        }

        public void Reset()
        {
            Edad = 0;
            Color = "";
        }
    }
}
