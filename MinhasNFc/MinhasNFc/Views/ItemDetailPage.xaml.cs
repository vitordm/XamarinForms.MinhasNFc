using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MinhasNFc.Models;
using MinhasNFc.ViewModels;

namespace MinhasNFc.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;

        public ItemDetailPage(Item item)
        {
            InitializeComponent();

            BindingContext = this.viewModel = new ItemDetailViewModel(item);
        }

        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = this.viewModel = new ItemDetailViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Item>(this, "OnItemSave", (Item item) =>
            {
                Retornar();
            });

            MessagingCenter.Subscribe<string>(this, "OnItemSaveError", (msg) =>
            {
                DisplayAlert("Erro", msg, "Ok");
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            MessagingCenter.Unsubscribe<Item>(this, "OnItemSave");
            MessagingCenter.Unsubscribe<string>(this, "OnItemSaveError");
        }

        private void Cancel_Clicked(object sender, EventArgs e)
        {
            Retornar();
        }

        private void Retornar()
        {
            Navigation.PopAsync(true);
        }
        
    }
}