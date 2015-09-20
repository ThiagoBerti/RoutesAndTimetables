using RoutesAndTimetables.Business.DataObjects;
using RoutesAndTimetables.Business.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutesAndTimetables.Business.Services
{
    public interface INavigationService
    {
        void GoToRouteDetails(RouteDetailsViewModel model);
    }
}
