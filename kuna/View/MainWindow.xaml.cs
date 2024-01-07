using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.InteropServices;
using kuna.View;
using kuna.ViewModels;
using kuna.Models;//Libreria para los eventos 

namespace kuna
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow window;
        private MainViewModel viewModel = new MainViewModel();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = viewModel;
            ActualizarImagenMain(ServiceUser.user.ProfilePicture);
            window = this;
        }

        public void ActualizarImagenMain(string url)
        {
            imagenMain.ImageSource = CargarImagen(url);
        }

        [DllImport("user32.dll")] //Para usar el mouse para capturar los movimientos del mouse
        public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        //Este metodo hace que la ventana sea responsive
        private void pnlControlBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowInteropHelper helper = new WindowInteropHelper(this);
            SendMessage(helper.Handle, 161, 2, 0);
        }
        private void pnlControlBar_MouseEnter(object sender, MouseEventArgs e)
        {
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }
        
        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                this.WindowState = WindowState.Normal;
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


        //Boton cerrar sesion , ates de que se cierre muestra un pop up de confirmacion
        private void btnCloseSession_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult cerrarSesion = MessageBox.Show("¿Seguro que quieres cerrar sesión?", "Cerrar sesión", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (cerrarSesion == MessageBoxResult.Yes)
            {
                LoginView loginView = new LoginView();
                loginView.Show();
                this.Close();
            }
        }

        public void ActualizarBotonesMostrarPerfil()
        {
            btn_Perfil.IsChecked = true;
        }

        private void BtnPost_Click(object sender, RoutedEventArgs e)
        {
            
            //this.Visibility = Visibility.Hidden;
            //MainWindow mainView = new MainWindow();
            //PostearView.Show();
            

        }


        private void BtnBorrarUser_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult borrarUser = MessageBox.Show("Este boton sirve para borra tu usuario , ¿Seguro que quieres borrar tu cuenta?", "Eliminar cuenta", MessageBoxButton.YesNo, MessageBoxImage.Question);

        }
    }
}