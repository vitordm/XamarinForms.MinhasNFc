﻿using System;

using MinhasNFc.Models;
using MinhasNFc.Services;
using Xamarin.Forms;

namespace MinhasNFc.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public Command SalvarComando { get; private set; }
        public bool HabilitarEdicao { get; private set; }

        private readonly ItemService _itemService;
        private readonly bool _isNovoItem;

        public ItemDetailViewModel(Item item = null)
        {
            if (item == null)
            {
                Title = "Novo Item";
                item = new Item
                {
                    CriadoEm = DateTime.Now
                };
                _isNovoItem = true;
            }
            else
            {
                Title = "Editar Item";
                _isNovoItem = false;
            }

            Item = item;
            HabilitarEdicao = !item.Sincronizado;

            SalvarComando = new Command(() => ExecuteSalvarComando());

            _itemService = new ItemService();
        }

        public void ExecuteSalvarComando()
        {
            if (string.IsNullOrWhiteSpace(Item.QrCode))
            {
                MessagingCenter.Send<string>("QrCode em branco", "OnItemSaveError");
                return;
            }

            try
            {
                if (_isNovoItem)
                {
                    Item.CriadoEm = DateTime.Now;
                    Item.Sincronizado = false;
                    _itemService.Insert(Item);
                    MessagingCenter.Send<Item>(Item, "OnItemSave");
                }
                else
                {
#if DEBUG
                    _itemService.Update(Item);
                    MessagingCenter.Send<Item>(Item, "OnItemSave");
#else
                    MessagingCenter.Send<string>("Não é possível editar o item!", "OnItemSaveError");
#endif
                }
                
            }
            catch(Exception ex)
            {
                MessagingCenter.Send<string>(ex.Message, "OnItemSaveError");
            }
            
        }

        public void AtualizaQrCode(string codigoQrCode)
        {
            Item.QrCode = codigoQrCode;

            OnPropertyChanged(nameof(Item));
        }
    }
}
