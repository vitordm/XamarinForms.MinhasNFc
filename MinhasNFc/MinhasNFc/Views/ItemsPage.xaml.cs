using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MinhasNFc.Models;
using MinhasNFc.Views;
using MinhasNFc.ViewModels;
using MinhasNFc.Services.Store;
using System.Diagnostics;

namespace MinhasNFc.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;

        NFcService _service = new NFcService();

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            /*
            var item = args.SelectedItem as Item;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
            */
        }

        void AddItem_Clicked(object sender, EventArgs e)
        {
            try
            {
                _service.CriarTabela();
                DisplayAlert("Alert", "You have been alerted", "OK");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                DisplayAlert("Alert", "Deu xabu", "OK");

            }


            //await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            /*
            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
            */
        }
    }
}