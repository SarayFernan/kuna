using kuna.Models;
using kuna.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kuna.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {

        private ViewModelBase currentPostView;

        public ViewModelBase CurrentPostView
        {
            get
            {
                return currentPostView;
            }

            set
            {
                currentPostView = value;
                OnPropertyChanged(nameof(currentPostView));//Para actualizar la vista 
            }
        }

        public List<PostModel> CargarPosts()
        {
            return ServicePost.GetPosts();
        }
    }
}
