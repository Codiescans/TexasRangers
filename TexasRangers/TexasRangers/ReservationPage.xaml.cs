using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexasRangers.Model;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TexasRangers
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReservationPage : ContentPage
    {
        public ReservationPage()
        {
            InitializeComponent();
        }
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var reservations = (Reservation)BindingContext;
            reservations.Date = DateTime.UtcNow;
            await App.Database.SaveNoteAsync(reservations);
            await Navigation.PopAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var reservations = (Reservation)BindingContext;
            await App.Database.DeleteNoteAsync(reservations);
            await Navigation.PopAsync();
        }
    }
}