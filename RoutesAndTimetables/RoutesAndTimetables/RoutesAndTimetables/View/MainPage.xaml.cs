
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
            //(BindingContext as BraviQuests.ViewModels.MainPageViewModel).QuestTappedCommand.Execute(e.Item as BraviQuests.DataObjects.Quest);
        }

        private void OnSearchButtonPressed(object sender, EventArgs args)
        {

        }
    }
}
