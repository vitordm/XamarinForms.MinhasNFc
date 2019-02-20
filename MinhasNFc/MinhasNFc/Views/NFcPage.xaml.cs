using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MinhasNFc.Models;
using MinhasNFc.ViewModels;

namespace MinhasNFc.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NFcPage : ContentPage
    {
        private readonly NFcViewModel _viewModel;

        public NFcPage(NFc nfc)
        {
            InitializeComponent();
            BindingContext = _viewModel = new NFcViewModel(nfc);
   
        }

        
    }
}