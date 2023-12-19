using kuna.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace kuna.View
{
    /// <summary>
    /// Lógica de interacción para PlantillaPost.xaml
    /// </summary>
    public partial class PlantillaPost : UserControl
    {
        private string postId;
        public PlantillaPost(PostModel post)
        {
            InitializeComponent();
            postId = post.Id;
            txtNombre.Text += post.Name;
            txtEspecie.Text += post.Species;
            txtEdad.Text += post.Age.ToString();
            txtRaza.Text += post.Breed;
            imagen.Source = CargarImagen(post.Image);
            txtTamanio.Text += post.Size;
            txtColor.Text += post.Color;
            txtCaracteristicas.Text += post.Characteristics;
        }

        private BitmapImage CargarImagen(string url)
        {
            BitmapImage imagen = new BitmapImage();

            imagen.BeginInit();
            imagen.UriSource = new Uri(url, UriKind.RelativeOrAbsolute);
            imagen.EndInit();

            return imagen;
        }

        //Opcion que elimina el post y todo los datos de este 
        //TODO ventana emergente :)
        public void MenuEliminar_Click(object sender, RoutedEventArgs e)
        {
            ServicePost.DeletePost(postId);
        }
    }
}
