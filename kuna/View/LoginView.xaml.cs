
using kuna.Models;
using kuna.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace kuna.View
{
    /// <summary>
    /// Lógica de interacción para LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        private LoginViewModel viewModel = new LoginViewModel();

        public LoginView()
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //PAra que la pantalla se pueda arrastrar
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        //MInimizar pantalla
        private void BtnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        //Cerra pantalla
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        //Boton logear , este metodo cierra la ventana login y muestra el main view
        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (viewModel.Login())
            {
                this.Visibility = Visibility.Hidden;
                MainWindow mainView = new MainWindow();
                mainView.Show();
                this.Close();
            }
        }


        private void btnResetSesion_Click(object sender, RoutedEventArgs e)
        {
            txtUser.Text = string.Empty;
            pass.Password.Clear();
            
            
        }
        private void txtUser_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
