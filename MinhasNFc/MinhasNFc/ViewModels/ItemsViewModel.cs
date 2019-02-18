using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;

using Xamarin.Forms;

using MinhasNFc.Models;
using MinhasNFc.Views;
using MinhasNFc.Interfaces.Services;
using MinhasNFc.Services;

namespace MinhasNFc.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<Item> Items { get; set; }
        public Command LoadItemsCommand { get; set; }
        private readonly IItemService _itemService;

        public ItemsViewModel()
        {
            Items = new ObservableCollection<Item>();
            Title = "Minhas NF-c";
            _itemService = new ItemService();

            LoadItemsCommand = new Command(() => ExecuteLoadItemsCommand());
        }

        void ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();

                var items = _itemService.List();
                foreach(var item in items)
                {
                    Items.Add(item);
                }

                OnPropertyChanged(nameof(Items));

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

        public void DeletarItem(Item item)
        {
            _itemService.Delete(item);
            AtualizarLista();
        }

        public void SincronizarItem(Item item)
        {
            _itemService.Sincronizar(item);
            AtualizarLista();
        }
    }
}