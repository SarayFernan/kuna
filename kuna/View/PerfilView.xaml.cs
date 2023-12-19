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
    /// <summary>
    /// Lógica de interacción para PerfilView.xaml
    /// </summary>
    public partial class PerfilView : UserControl
    {
        private PerfilViewModel viewModel = new PerfilViewModel();
        public PerfilView()
        {
            InitializeComponent();
            DataContext = viewModel;
        }


        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
