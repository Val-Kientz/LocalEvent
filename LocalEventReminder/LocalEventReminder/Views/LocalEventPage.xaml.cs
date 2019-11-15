using LocalEventReminder.Models;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LocalEventReminder.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LocalEventPage : ContentPage
    {
        public LocalEventPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await App.Database.GetEventsAsync();
        }

        private async void OnNoteAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LocalEventEntryPage
            {
                BindingContext = new LocalEvent()
            });
        }

        private async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new LocalEventEntryPage
                {
                    BindingContext = e.SelectedItem as LocalEvent
                });
            }
        }
    }
}