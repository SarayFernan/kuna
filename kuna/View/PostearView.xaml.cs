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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace kuna.View
{
    public partial class PostearView : UserControl
    {
        private PostearViewModel viewModel = new PostearViewModel();

        public PostearView()
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        
        private void BtnPost_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Postear();
        }

        //Limpiar elemntos de los textbox
        public void BtnLimpiarCampos_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Limpiar();
        }

    }
}
