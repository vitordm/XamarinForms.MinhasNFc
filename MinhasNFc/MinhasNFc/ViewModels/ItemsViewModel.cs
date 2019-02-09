using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using MinhasNFc.Models;
using MinhasNFc.Views;

namespace MinhasNFc.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<NFc> Nfcs { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            Nfcs = new ObservableCollection<NFc>();
            Title = "Minhas NF-c";
            /*
            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as Item;
                Items.Add(newItem);
                await DataStore.AddItemAsync(newItem);
            });*/
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
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