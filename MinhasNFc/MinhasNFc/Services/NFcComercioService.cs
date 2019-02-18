using MinhasNFc.Interfaces.Services;
using MinhasNFc.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinhasNFc.Services
{
    class NFcComercioService : GenericService<NFcComercio>, IStoreService<NFcComercio>
    {
        public NFcComercio FindByCnpjOrNew(NFcComercio comercio)
        {
            using (var conn = SQLiteDb.GetConnection())
            {
                var comercioExistente = conn.Table<NFcComercio>()
                    .Where(nfcc => nfcc.CNPJ == comercio.CNPJ)
                    .FirstOrDefault();
                if(comercioExistente == null)
                {
                    return Insert(comercio);
                }

                return comercioExistente;
            }
        }
    }
}
