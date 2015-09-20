using RoutesAndTimetables.Business.DataObjects;
using RoutesAndTimetables.Business.ViewModels;
using RoutesAndTimetables.Ui.Services;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace RoutesAndTimetables.Ui.View
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            
            BindingContext = new MainPageViewModel(new NavigationService());
        }


        private void RouteTapped(object sender, ItemTappedEventArgs e)
        {
            (BindingContext as MainPageViewModel).RouteTappedCommand.Execute(e.Item as Route);
        }

        private void OnSearchButtonPressed(object sender, EventArgs args)
        {
            (BindingContext as MainPageViewModel).RefreshCommand.Execute(null);
        }
    }
}
