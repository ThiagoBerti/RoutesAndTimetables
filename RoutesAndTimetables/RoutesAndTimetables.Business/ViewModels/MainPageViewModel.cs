using PropertyChanged;
using RoutesAndTimetables.Business.DataObjects;
using RoutesAndTimetables.Business.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutesAndTimetables.Business.ViewModels
{
    [ImplementPropertyChanged]
    public class MainPageViewModel
    {
        public MainPageViewModel(INavigationService navigation)
        {
            this.Query = string.Empty;
            this.Refresh();
        }
        private RoutesService service = new RoutesService();
        public string Query { get; set; }
        public bool IsLoading { get; set; }
        public ObservableCollection<Route> Routes { get; set; }
  

        public void Refresh()
        {
            this.IsLoading = true;
            this.Routes = new ObservableCollection<Route>(service.GetRoutes(this.Query));
            this.IsLoading = false;
        }

        
    }
}

