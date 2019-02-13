using MinhasNFc.Interfaces.Database;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MinhasNFc.Configurations
{
    public class DatabaseConfiguration
    {
        protected ISQLiteDb SQLiteDb => DependencyService.Get<ISQLiteDb>();


        public void Initialize()
        {
        }
    }
}
