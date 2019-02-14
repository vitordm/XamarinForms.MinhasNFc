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

        private void Cancel_Clicked(object sender, EventArgs e)
        {

        }

        private void Save_Clicked(object sender, EventArgs e)
        {

        }

        
    }
}