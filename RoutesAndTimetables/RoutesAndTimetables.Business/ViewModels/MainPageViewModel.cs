using PropertyChanged;
using RoutesAndTimetables.Business.DataObjects;
using RoutesAndTimetables.Business.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RoutesAndTimetables.Business.ViewModels
{
    [PropertyChanged.ImplementPropertyChanged]
    public class MainPageViewModel : BaseViewModel
    {
        public MainPageViewModel(INavigationService navigation) : base(navigation)
        {
            this.RefreshCommand = new Command(Refresh);   
            this.Query = string.Empty;
            
            this.Refresh(null);
        }
        
        public string Query { get; set; }
        public bool IsLoading { get; set; }
        public ObservableCollection<Route> Routes { get; set; }
        public Command RefreshCommand { get; set; }
        public Command<Route> RouteTappedCommand { get; set; }

        public void Refresh(object obj)
        {
            this.IsLoading = true;
            this.Routes = new ObservableCollection<Route>(service.GetRoutes(this.Query));
            this.IsLoading = false;
        }

        private void RouteTapped(Route route)
        {
            //navigationService.GoToRouteDetails(new RouteDetailsViewModel(navigationService) { Route = route });
        }

    }
}

