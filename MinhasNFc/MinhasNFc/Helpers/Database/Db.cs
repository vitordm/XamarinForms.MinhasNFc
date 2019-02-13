using MinhasNFc.Interfaces.Database;
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
    }
}
