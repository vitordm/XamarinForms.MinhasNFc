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
using MinhasNFc.Interfaces.Database;

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
            viewModel.AtualizarLista();
            MessagingCenter.Subscribe<string>(this, "OnItemError", (msg) =>
            {
                DisplayAlert("Erro", msg, "Ok");
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<string>(this, "OnItemError");

        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            var db = DependencyService.Get<ISQLiteDb>();
            db?.ExportaDatabase();
        }

        private async void MenuItemDeletarItem_Clicked(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var item = menuItem.CommandParameter as Item;
            if (item == null || item.Sincronizado)
                return;

            var resposta = await DisplayAlert("Deletar Item", "Você deseja realmente deletar esse item?", "Sim", "Não");
            if (resposta)
                viewModel.DeletarItem(item);
        }

        private void MenuItemSincronizar_Clicked(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var item = menuItem.CommandParameter as Item;
            if (item.Sincronizado || item.NFcId > 0)
                return;

            viewModel.SincronizarItem(item);
            //viewModel.AtualizarLista();
        }
    }
}