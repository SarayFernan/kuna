using kuna.Models;
using kuna.View;
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

        // Método para obtener la lista de posts
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

        // Constructor
        public HomeViewModel()
        {
            Especie = "Todas";
            Tamanio = "Cualquiera";
            Color = "";
        }

        // Método para filtrar posts
        public List<PostModel> GetPostsFiltrados()
        {
            // Lista que contendrá los posts filtrados
            List<PostModel> filtrados = new List<PostModel>();

            foreach (PostModel post in posts)
            {
                // Condiciones de filtrado:
                // 1. Si la especie es "Todas" o la especie del post coincide con la especie seleccionada
                // 2. Si la edad es 0 o la edad del post está dentro del rango (Edad - 2) y (Edad + 2)
                // 3. Si el tamaño es "Cualquiera" o el tamaño del post coincide con el tamaño seleccionado
                // 4. Si el color del post contiene el color seleccionado (ignorando mayúsculas y minúsculas)
                if ((Especie.Equals("Todas") || post.Species.Equals(Especie))
                    && (Edad == 0) || ((post.Age >= Edad - 2) && (post.Age <= Edad + 2))
                    && (Tamanio.Equals("Cualquiera") || post.Size.Equals(Tamanio))
                    && post.Color.IndexOf(Color, StringComparison.OrdinalIgnoreCase) >= 0) // equivalente a un supuesto método containsIgnoreCase
                {
                    // Agrega el post a la lista de filtrados
                    filtrados.Add(post);
                }
            }

            return filtrados;
        }

        // Método para actualizar después de eliminar un post
        public void UpdateAfterDelete(PlantillaPost eliminado)
        {
            posts.Remove(eliminado.Post);
        }

        // Método para restablecer valores
        public void Reset()
        {
            Edad = 0;
            Color = "";
        }
    }
}
