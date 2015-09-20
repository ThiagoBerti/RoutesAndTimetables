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
    public class RouteDetailsViewModel : BaseViewModel
    {

        public RouteDetailsViewModel(INavigationService navigation, Route route) : base(navigation)
        {
            this.Stops = new ObservableCollection<Stop>();
            this.Departures = new List<Departure>();
            this.WeeklyDepartures = new ObservableCollection<Departure>();
            this.SaturdayDepartures = new ObservableCollection<Departure>();
            this.SundayDepartures = new ObservableCollection<Departure>();
            //Kind of had to implement tabs and subtabs by hand.
            this.ShowStopsCommand = new Command(ShowStops, () => !IsShowingStops);
            this.ShowDeparturesCommand = new Command(ShowDepartures, ()=>!IsShowingDepartures);
            this.ShowWeekdayCommand = new Command(ShowWeekday, () => !IsShowingWeekday);
            this.ShowSaturdayCommand = new Command(ShowSaturday, () => !IsShowingSaturday);
            this.ShowSundayCommand = new Command(ShowSunday, () => !IsShowingSunday);
            this.IsShowingStops = true;
            this.IsShowingWeekday = true;
            this.Route = route;

            this.LoadStops();
            this.LoadDepartures();
        }
        public Route Route { get; set; }
        public ObservableCollection<Stop> Stops { get; set; }
        public List<Departure> Departures { get; set; }
        public ObservableCollection<Departure> WeeklyDepartures { get; set; }
        public ObservableCollection<Departure> SaturdayDepartures { get; set; }
        public ObservableCollection<Departure> SundayDepartures { get; set; }


        #region Tabs and controls Visibility Logic
        public bool HasSaturdayDeparture { get; set; }
        public bool HasSundayDeparture { get; set; }
        public Command ShowStopsCommand { get; set; }
        public Command ShowDeparturesCommand { get; set; }
        public Command ShowWeekdayCommand { get; set; }
        public Command ShowSaturdayCommand { get; set; }
        public Command ShowSundayCommand { get; set; }
        public bool IsShowingStops { get; set; }
        public bool IsShowingDepartures { get; set; }
        public bool IsShowingWeekday { get; set; }
        public bool IsShowingSaturday { get; set; }
        public bool IsShowingSunday { get; set; }
        

        public void ShowStops()
        {
            this.IsShowingStops = true;
            this.IsShowingDepartures = false;
            this.ShowStopsCommand.ChangeCanExecute();
            this.ShowDeparturesCommand.ChangeCanExecute();
        }

        public void ShowDepartures()
        {
            this.IsShowingStops = false;
            this.IsShowingDepartures = true;
            this.ShowStopsCommand.ChangeCanExecute();
            this.ShowDeparturesCommand.ChangeCanExecute();
        }

        public void ShowWeekday()
        {
            this.IsShowingWeekday = true;
            this.IsShowingSaturday = false;
            this.IsShowingSunday = false;
            this.ShowWeekdayCommand.ChangeCanExecute();
            this.ShowSaturdayCommand.ChangeCanExecute();
            this.ShowSundayCommand.ChangeCanExecute();
        }

        public void ShowSaturday()
        {
            this.IsShowingWeekday = false;
            this.IsShowingSaturday = true;
            this.IsShowingSunday = false;
            this.ShowWeekdayCommand.ChangeCanExecute();
            this.ShowSaturdayCommand.ChangeCanExecute();
            this.ShowSundayCommand.ChangeCanExecute();
        }

        public void ShowSunday()
        {
            this.IsShowingWeekday = false;
            this.IsShowingSaturday = false;
            this.IsShowingSunday = true;
            this.ShowWeekdayCommand.ChangeCanExecute();
            this.ShowSaturdayCommand.ChangeCanExecute();
            this.ShowSundayCommand.ChangeCanExecute();
        }
        #endregion
        public async void LoadStops()
        {
            this.Stops = new ObservableCollection<Stop>(await service.GetStops(this.Route.Id));
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
            this.HasSaturdayDeparture = this.SaturdayDepartures.Any();
        }

        private async void LoadSundayDepartures()
        {
            this.SundayDepartures = new ObservableCollection<Departure>(this.Departures.Where(x => x.Calendar == "SUNDAY"));
            this.HasSundayDeparture = this.SundayDepartures.Any();
        }
    }
}
