using RoutesAndTimetables.Business.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutesAndTimetables.Business.ViewModels
{
    public class BaseViewModel
    {
        protected INavigationService navigationService;
        protected RoutesService service;
        protected BaseViewModel(INavigationService navigation)
        {
            this.navigationService = navigation;
            this.service = new RoutesService();
        }
    }
}
