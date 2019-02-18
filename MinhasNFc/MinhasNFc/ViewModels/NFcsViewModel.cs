using MinhasNFc.Models;
using MinhasNFc.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace MinhasNFc.ViewModels
{
    public class NFcsViewModel : BaseViewModel
    {
        private readonly NFcService _nfcService;

        public ObservableCollection<NFc> NFcs { get; set; }
        public Command LoadItemsCommand { get; set; }

        public NFcsViewModel()
        {
            _nfcService = new NFcService();
            Title = "Minhas NFc-e";
            NFcs = new ObservableCollection<NFc>();
            LoadItemsCommand = new Command(() => ExecuteLoadItemsCommand());
        }

        void ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                NFcs.Clear();

                var nfcs = _nfcService.ListWithComercio();
                foreach (var nfc in nfcs)
                {
                    NFcs.Add(nfc);
                }

                OnPropertyChanged(nameof(NFcs));

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void AtualizarLista() => ExecuteLoadItemsCommand();
    }
}
