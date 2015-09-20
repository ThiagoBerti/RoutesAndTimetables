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
            this.Stops = new ObservableCollection<Stop>();
            this.Departures = new List<Departure>();
            this.WeeklyDepartures = new ObservableCollection<Departure>();
            this.SaturdayDepartures = new ObservableCollection<Departure>();
            this.SundayDepartures = new ObservableCollection<Departure>();
            this.Route = route;

            this.LoadStops();
            this.LoadDepartures();
            //HasWeekdayDeparture = true;
        }
        public Route Route { get; set; }
        public ObservableCollection<Stop> Stops { get; set; }
        public ObservableCollection<Departure> WeeklyDepartures { get; set; }
        public ObservableCollection<Departure> SaturdayDepartures { get; set; }
        public ObservableCollection<Departure> SundayDepartures { get; set; }
        public List<Departure> Departures { get; set; }
        public bool IsLoadingStops { get; set; }
        public bool HasWeekdayDeparture { get; set; }

        public async void LoadStops()
        {
            this.IsLoadingStops = true;
            this.Stops = new ObservableCollection<Stop>(await service.GetStops(this.Route.Id));
            this.IsLoadingStops = false;
        }

        public async void LoadDepartures()
        {
            this.Departures = new List<Departure>(await service.GetDepartures(this.Route.Id));
            this.LoadWeeklyDepartures();
            this.LoadSaturdayDepartures();
            this.LoadSundayDepartures();
        }

        private async void LoadWeeklyDepartures()
        {
            this.WeeklyDepartures = new ObservableCollection<Departure>(this.Departures.Where(x => x.Calendar == "WEEKDAY"));
        }

        private async void LoadSaturdayDepartures()
        {
            this.SaturdayDepartures = new ObservableCollection<Departure>(this.Departures.Where(x => x.Calendar == "SATURDAY"));
        }

        private async void LoadSundayDepartures()
        {
            this.SundayDepartures = new ObservableCollection<Departure>(this.Departures.Where(x => x.Calendar == "SUNDAY"));
        }
    }
}
