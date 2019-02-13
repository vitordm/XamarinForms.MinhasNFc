using MinhasNFc.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinhasNFc.Services.Store
{
    public class NFcService : BaseStoreSevice<NFc>
    {
        public NFcService()
        {

        }

        public void CriarTabela()
        {
            using(var conn = SQLiteDb.Connection)
            {
                var count = conn.CreateTable<NFc>();
            }
            
        }
    }
}
