using MinhasNFc.Interfaces.Services;
using MinhasNFc.Models;
using MinhasNFc.Extensions.Database;
using MyParserNFc;

using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Linq;

namespace MinhasNFc.Services
{
    public class ItemService : GenericService<Item>, IItemService
    {
        private readonly NFcService _nfcService;

        public ItemService()
        {
            _nfcService = new NFcService();
        }

        public override Item GetById(int id)
        {
            var item = base.GetById(id);
            if (item != null && item.NFcId != null)
            {
                item.NFc = _nfcService.GetById((int)item.NFcId);
            }

            return item;
        }

        public void Sincronizar(Item item)
        {
            var factoryNfc = new FactoryNFc(item.QrCode);
            var nfc = factoryNfc.Factory();
            var myNfc = _nfcService.Insert(NFcOnlineToNfcMobo(nfc));
            if (myNfc != null)
            {
                item.Sincronizado = true;
                item.NFcId = myNfc.Id;
                item.NFc = myNfc;
                this.Update(item);

            }
        }

        private NFc NFcOnlineToNfcMobo(MyParserNFc.Models.NFc nfc)
        {
            var nfcMobo = new NFc()
            {
                Numero = nfc.Numero,
                Serie = nfc.Serie,
                DataNFc = nfc.DataNFc,
                ValorTotal = nfc.ValorTotal,
                ValorDescontos = nfc.ValorDescontos,
                FormaPagamento = nfc.FormaPagamento,
                ValorPago = nfc.ValorPago,
                ConsumidorIdentificado = nfc.ConsumidorIdentificado,
                DocumentoConsumidor = nfc.DocumentoConsumidor
            };

            var nfcComercio = new NFcComercio
            {
                CNPJ = nfc.Comercio.CNPJ,
                IE = nfc.Comercio.IE,
                RazaoSocial = nfc.Comercio.RazaoSocial
            };

            nfcMobo.Comercio = nfcComercio;

            if (nfc.Itens.Any())
            {
                foreach (var item in nfc.Itens)
                {
                    nfcMobo.Itens.Add(new NFcItem
                    {
                        Codigo = item.Codigo,
                        Descricao = item.Descricao,
                        Qtde =item.Qtde,
                        Un = item.Un,
                        ValorTotal = item.ValorTotal,
                        ValorUnitario = item.ValorUnitario
                    });
                }
            }

            return nfcMobo;
        }


    }
}
