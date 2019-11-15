using LocalEventReminder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LocalEventReminder.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LocalEventEntryPage : ContentPage
	{
		public LocalEventEntryPage ()
		{
			InitializeComponent ();
		}
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var newEvent = (LocalEvent)BindingContext;
            newEvent.CreationDate = DateTime.Now;
            await App.Database.SaveEventAsync(newEvent);
            await Navigation.PopAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var eventToDelete = (LocalEvent)BindingContext;
            await App.Database.DeleteEventAsync(eventToDelete);
            await Navigation.PopAsync();
        }
    }
}