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
        /*
         * Se necesita una clase aparte de user para tener por un lado la estructura exacta
         * de la autenticación ya que no puede sobrar ni faltar nada y por otro los datos de la aplicación
         */
        public PerfilView()
        {
            InitializeComponent();
            //imagen.ImageSource = CargarImagen(ServiceUser.user.ProfilePicture);
        }

        private BitmapImage CargarImagen(string url)
        {
            BitmapImage imagen = new BitmapImage();

            imagen.BeginInit();
            imagen.UriSource = new Uri(url, UriKind.RelativeOrAbsolute);
            imagen.EndInit();

            return imagen;
        }



        
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            ((PerfilViewModel) DataContext).Edit();
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult eliminarCuenta = MessageBox.Show("¿Eliminar la cuenta? Se perderán todos los datos y posts", "Eliminar cuenta", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);

            if (eliminarCuenta == MessageBoxResult.Yes)
            {
                eliminarCuenta = MessageBox.Show("Esto no se puede deshacer. ¿Seguro que quieres eliminar la cuenta?", "Eliminar cuenta", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (eliminarCuenta == MessageBoxResult.Yes) {
                    ServiceUser.DeleteUser(ServiceUser.user.Name);
                    LoginView loginView = new LoginView();
                    loginView.Show();
                    MainWindow.window.Close();
                }
            }
        }

    }
}
