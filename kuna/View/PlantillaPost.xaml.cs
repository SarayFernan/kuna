using kuna.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
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
        private PostModel post;

        public PostModel Post
        {
            get { return post; }

            set
            {
                post = value;
            }
        }

        public PlantillaPost(PostModel post)
        {
            InitializeComponent();
            this.post = post;
            txtNombre.Text += post.Name;
            txtEspecie.Text += post.Species;
            txtEdad.Text += post.Age.ToString();
            txtRaza.Text += post.Breed;
            imagen.Source = CargarImagen(post.Image);
            txtTamanio.Text += post.Size;
            txtColor.Text += post.Color;
            txtCaracteristicas.Text += post.Characteristics;
            imagenPlantilla.ImageSource = CargarImagen(ServiceUser.GetUserAccount(post.User).ProfilePicture);

            if (!ServiceUser.user.Name.Equals(post.User))
            {
                btnEliminar.Visibility = Visibility.Hidden;
            }
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
        
        public void MenuEliminar_Click(object sender, RoutedEventArgs e)
        {
            
            MessageBoxResult eliminarPost = MessageBox.Show("¿Seguro que quieres eliminar la publicación?", "Eliminar publicación", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (eliminarPost == MessageBoxResult.Yes)
            {
                ServicePost.DeletePost(post.Id);
                HomeView.view.UpdateAfterDelete(this);
            }
        }
    }
}
