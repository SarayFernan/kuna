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
    /// <summary>
    /// Lógica de interacción para HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        private HomeViewModel viewModel = new HomeViewModel();
        public HomeView()
        {
            InitializeComponent();
            DataContext = viewModel;
            CargarPosts();
        }


        public void CargarPosts()
        {
            List<PostModel> posts = viewModel.CargarPosts();

            foreach (var post in posts)
            {
                PlantillaPost p = new PlantillaPost(post);
                VistaPosts.Children.Add(p);
            }
        }
    }
}
