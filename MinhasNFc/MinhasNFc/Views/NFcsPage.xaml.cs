using MinhasNFc.Models;
using MinhasNFc.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MinhasNFc.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NFcsPage : ContentPage
    {
        private readonly NFcsViewModel _viewModel;
        
        public NFcsPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new NFcsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.AtualizarLista();
        }

        void OnNFcSelected(object sender, SelectedItemChangedEventArgs args)
        {
            if (!(args.SelectedItem is NFc nfc))
                return;

            Navigation.PushAsync(new NFcPage(nfc));
            NFcListView.SelectedItem = null;
        }

        private void AddNFcToolbar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ItemsPage());
        }
    }
}
