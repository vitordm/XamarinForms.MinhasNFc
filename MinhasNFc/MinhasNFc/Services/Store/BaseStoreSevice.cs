using MinhasNFc.Interfaces.Database;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MinhasNFc.Services.Store
{
    public abstract class BaseStoreSevice
    {
        protected ISQLiteDb SQLiteDb => DependencyService.Get<ISQLiteDb>();
    }
}
