using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using PCRepair.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PCRepair.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PCRepairPage : ContentPage
    {

        public PCRepairPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Retrieve all the tasks from the database, and set them as the
            // data source for the CollectionView.
            collectionView.ItemsSource = await App.Database.GetMyRequestsAsync();
        }

        async void OnAddClicked(object sender, EventArgs e)
        {
            // Navigate to the MyRequestEntryPage, without passing any data.
            await Shell.Current.GoToAsync(nameof(MyRequestEntryPage));
        }

        async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                // Navigate to the MyRequestEntryPage, passing the filename as a query parameter.
                MyRequest task = (MyRequest)e.CurrentSelection.FirstOrDefault();
                await Shell.Current.GoToAsync($"{nameof(MyRequestEntryPage)}?{nameof(MyRequestEntryPage.ItemId)}={task.ID.ToString()}");
            }
        }

        
    }
}