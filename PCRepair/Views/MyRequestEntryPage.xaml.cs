using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PCRepair.Models;

namespace PCRepair.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class MyRequestEntryPage : ContentPage
    {
        public string ItemId
        {
            set
            {
                LoadRequest(value);
            }
        }

        public MyRequestEntryPage()
        {
            InitializeComponent();

            // Set th BindingContext of the page to a new MyRequest.
            BindingContext = new MyRequest();

        }

        async void LoadRequest(string itemId)
        {
            try
            {
                // Retrieve the task and set it as the BindingContext of the page.
                int id = Convert.ToInt32(itemId);
                MyRequest request = await App.Database.GetMyRequestAsync(id);
                BindingContext = request;
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка при загрузке заявки");
            }
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var request = (MyRequest)BindingContext;

            if (request.ID == 0) {
                request.CreateDate = DateTime.Now;
            }
            if (request.Completed)
            {
                request.CloseDate = DateTime.Now;
            }

            if (!string.IsNullOrWhiteSpace(request.ClientName))
            {
                await App.Database.SaveMyRequestAsync(request);
            }

            // Navigate backwards
            await Shell.Current.GoToAsync("..");
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var task = (MyRequest)BindingContext;

            await App.Database.DeleteMyRequestAsync(task);

            // Navigate backwards
            await Shell.Current.GoToAsync("..");
        }
    }
}