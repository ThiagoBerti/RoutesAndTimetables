using RoutesAndTimetables.Business.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoutesAndTimetables.Business.ViewModels;
using RoutesAndTimetables.Ui.View;

namespace RoutesAndTimetables.Ui.Services
{
    public class NavigationService : INavigationService
    {
        public void GoToRouteDetails(RouteDetailsViewModel model)
        {
            RouteDetailsPage page = new RouteDetailsPage();
            page.BindingContext = model;
            App.Current.MainPage.Navigation.PushAsync(page);
        }
    }
}
