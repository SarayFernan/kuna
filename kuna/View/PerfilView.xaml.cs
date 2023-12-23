using kuna.Model;
using kuna.Models;
using kuna.ViewModel;
using kuna.ViewModels;
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
    public partial class PerfilView : UserControl
    {
        private PerfilViewModel viewModel = new PerfilViewModel();

        /*
         * Se necesita una clase aparte de user para tener por un lado la estructura exacta
         * de la autenticación ya que no puede sobrar ni faltar nada y por otro los datos de la aplicación
         */
        public PerfilView()
        {
            InitializeComponent();
            DataContext = viewModel;
            nombre.Text = ServiceUser.user.Name;
            sobreMi.Text = ServiceUser.user.AboutMe;
            imagen.ImageSource = CargarImagen(ServiceUser.user.ProfilePicture);
        }

        private BitmapImage CargarImagen(string url)
        {
            BitmapImage imagen = new BitmapImage();

            imagen.BeginInit();
            imagen.UriSource = new Uri(url, UriKind.RelativeOrAbsolute);
            imagen.EndInit();

            return imagen;
        }



        //TODO 
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
