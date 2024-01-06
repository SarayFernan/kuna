using kuna.Models;
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
    public partial class PerfilEditView : UserControl
    {
        private PerfilEditViewModel viewModel = new PerfilEditViewModel();

        public PerfilEditView()
        {
            InitializeComponent();
            DataContext = viewModel;
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainWindow.window.ActualizarImagenMain(imagen.Text);
                viewModel.Edit();
            }
            catch
            {
                MessageBox.Show("Ruta no válida");//Si la imagen no es valida muestra un popo up de error 
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

    }
}
