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
        public static HomeView view;
        private HomeViewModel viewModel = new HomeViewModel();
        public HomeView()
        {
            InitializeComponent();
            DataContext = viewModel;
            MostrarPosts(viewModel.GetPosts());
            view = this;
        }


        //Metodo para mostrear los post en el home
        public void MostrarPosts(List<PostModel> posts)
        {
            VistaPosts.Children.Clear();

            foreach (var post in posts)
            {
                PlantillaPost p = new PlantillaPost(post);
                VistaPosts.Children.Add(p);
            }
        }

        private void AplicarClick(object sender, RoutedEventArgs e)
        {
            MostrarPosts(viewModel.GetPostsFiltrados());
        }

        //Eliminar datos de los campos de filtros
        private void ResetClick(object sender, RoutedEventArgs e)
        {
            MostrarPosts(viewModel.GetPosts());
            viewModel.Reset();
        }


        public void UpdateAfterDelete(PlantillaPost eliminado)
        {
            viewModel.UpdateAfterDelete(eliminado);
            VistaPosts.Children.Remove(eliminado);
        }
    }
}
