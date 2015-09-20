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
    [PropertyChanged.ImplementPropertyChanged]
    public class RouteDetailsViewModel : BaseViewModel
    {
        
        public RouteDetailsViewModel(INavigationService navigation, Route route) : base(navigation)
        {
            Stops = new ObservableCollection<Stop>();
            this.Route = route;
            LoadStops();
        }
        public Route Route { get; set; }
        public ObservableCollection<Stop> Stops { get; set; }
        public bool IsLoadingStops { get; set; }

        public async void LoadStops()
        {
            this.IsLoadingStops = true;
            this.Stops = new ObservableCollection<Stop>(await service.GetStops(this.Route.Id));
            this.IsLoadingStops = false;
        }
    }
}
