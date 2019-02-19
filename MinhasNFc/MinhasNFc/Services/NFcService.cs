﻿using MinhasNFc.Interfaces.Services;
using MinhasNFc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinhasNFc.Services
{
    public class NFcService : GenericService<NFc>, IStoreService<NFc>
    {
        private readonly NFcComercioService _nfcComercioService;
        private readonly NFcItemService _NFcItemService;

        public NFcService()
        {
            _nfcComercioService = new NFcComercioService();
            _NFcItemService = new NFcItemService();
        }

        public override NFc Insert(NFc data)
        {
            if (data.ComercioId == 0 && data.Comercio != null)
            {
                data.Comercio = _nfcComercioService.FindByCnpjOrNew(data.Comercio);
                data.ComercioId = data.Comercio.Id;
            }

            var nfcInsert = base.Insert(data);
            data.Id = nfcInsert.Id;

            if (data.Itens.Any())
            {
                foreach(var item in data.Itens)
                {
                    item.NFcId = data.Id;
                    _NFcItemService.Insert(item);
                }
            }

            return data;
        }

        public IList<NFc> ListWithComercio()
        {
            var nfcs = List();
            if (nfcs.Any())
            {
                nfcs = nfcs.Select((nfc) =>
                {
                    nfc.Comercio = _nfcComercioService.GetById(nfc.ComercioId);
                    return nfc;
                })
                .ToList();
            }

            return nfcs;
        }
    }
}