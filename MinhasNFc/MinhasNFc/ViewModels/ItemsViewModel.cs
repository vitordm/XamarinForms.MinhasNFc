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
            LoadItemsCommand = new Command(() => ExecuteLoadItemsCommand());
            _itemService = new ItemService();


            /*
            MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as Item;
                Items.Add(newItem);
                await DataStore.AddItemAsync(newItem);
            });*/
        }

        void ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {

                var items = _itemService.List();
                Items.Clear();
                Items.Concat(items);

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
    }
}