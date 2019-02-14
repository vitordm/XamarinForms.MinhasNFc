
using MinhasNFc.Interfaces.Database;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MinhasNFc.Services
{
    public abstract class BaseService
    {
        protected ISQLiteDb SQLiteDb => DependencyService.Get<ISQLiteDb>();
    }
}
