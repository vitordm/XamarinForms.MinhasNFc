using MinhasNFc.Interfaces.Services;
using MinhasNFc.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinhasNFc.Services
{
    class NFcItemService : GenericService<NFcItem>, IStoreService<NFcItem>
    {
        public IList<NFcItem> ListByNFc(int nfcId)
        {
            using (var conn = SQLiteDb.GetConnection())
            {
                return conn.Table<NFcItem>()
                        .Where(item => item.NFcId == nfcId)
                        .ToList();
                    
            }
        }
    }
}
