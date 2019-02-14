using System;

using MinhasNFc.Models;

namespace MinhasNFc.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public ItemDetailViewModel(Item item = null)
        {
            if (item == null)
            {
                Title = "Novo Item";
                item = new Item
                {
                    CriadoEm = DateTime.Now
                };
            }
            else
            {
                Title = "Editar Item";
            }
            Item = item;
        }
    }
}
