using MinhasNFc.Interfaces.Models;
using System.Collections;
using System.Collections.Generic;

namespace MinhasNFc.Interfaces.Services
{
    public interface IStoreService<T> where T : class, IStoreModel
    {
        IList<T> List();
        T GetById(int Id);
        T Insert(T data);
        void Update(T data);
        void Delete(T data);
    }
}
