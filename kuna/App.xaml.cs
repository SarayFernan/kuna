using kuna.View;
using kuna.ViewModels;
using System.Configuration;
using System.Data;
using System.Windows;

namespace kuna
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected void AplicationStart(object sender , StartupEventArgs e)
        {
            LoginView loginView = new LoginView();
            loginView.Show();
        }
    }

}
