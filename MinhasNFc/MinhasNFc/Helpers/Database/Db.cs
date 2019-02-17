using MinhasNFc.Extensions.Database;
using MinhasNFc.Interfaces.Database;
using MinhasNFc.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MinhasNFc.Helpers.Database
{
    public class Db
    {
        public static ISQLiteDb _sqliteDb = null;
        public static ISQLiteDb SQLiteDb
        {
            get
            {
                if (_sqliteDb == null)
                {
                    _sqliteDb = DependencyService.Get<ISQLiteDb>();
                }

                return _sqliteDb;
            }
        }


        public void VerificarTabelas()
        {
            using (var conn = SQLiteDb.GetConnection())
            {
                if (!conn.TabelaExiste<Item>())
                {
                    conn.CriarTabela<Item>();
                }

                if (!conn.TabelaExiste<NFc>())
                {
                    conn.CriarTabela<NFc>();   
                }

                if (!conn.TabelaExiste<NFcComercio>())
                {
                    conn.CriarTabela<NFcComercio>();
                }

                if (!conn.TabelaExiste<NFcItem>())
                {
                    conn.CriarTabela<NFcItem>();
                }
            }
        }
    }
}
