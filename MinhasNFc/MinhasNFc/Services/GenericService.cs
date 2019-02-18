using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MinhasNFc.Interfaces.Database;
using MinhasNFc.Interfaces.Models;
using MinhasNFc.Interfaces.Services;

namespace MinhasNFc.Services
{
    public class GenericService<T> : BaseService,  IStoreService<T> where T : IStoreModel, new()
    {

        public virtual IList<T> List()
        {
            using (var conn = SQLiteDb.GetConnection())
            {

                return conn.Table<T>().ToList();
            }
        }

        public virtual T GetById(int id)
        {
            using (var conn = SQLiteDb.GetConnection())
            {
                return conn.Get<T>(id);
            }
        }

        public virtual T Insert(T data)
        {
            using (var conn = SQLiteDb.GetConnection())
            {
                conn.Insert(data);
                return data;
            }
        }

        public virtual void Update(T data)
        {
            using (var conn = SQLiteDb.GetConnection())
            {
                conn.Update(data);
            }
        }

        public virtual void Delete(T data)
        {
            using (var conn = SQLiteDb.GetConnection())
            {
                conn.Delete<T>(data.Id);
            }
        }
    }
}
