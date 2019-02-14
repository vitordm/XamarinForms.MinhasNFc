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
using System.Diagnostics;

namespace MinhasNFc.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            if (!(args.SelectedItem is Item item))
                return;

            Navigation.PushAsync(new ItemDetailPage(item));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        void AddItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ItemDetailPage());
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