using MinhasNFc.Interfaces.Database;
using MinhasNFc.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MinhasNFc.Services
{
    public abstract class BaseStoreSevice<T> : IStoreService<T> where T : class
    {

        protected ISQLiteDb SQLiteDb => DependencyService.Get<ISQLiteDb>();

        public abstract void Delete(T data);
        public abstract T GetById(int Id);
        public abstract T Insert(T data);
        public abstract IList<T> List();
        public abstract void Update(T data);
    }
}
