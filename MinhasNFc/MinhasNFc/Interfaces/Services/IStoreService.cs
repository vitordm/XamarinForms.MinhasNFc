using MinhasNFc.Interfaces.Models;
using System.Collections;
using System.Collections.Generic;

namespace MinhasNFc.Interfaces.Services
{
    public interface IStoreService<T> where T : IStoreModel, new()
    {
        IList<T> List();
        T GetById(int id);
        T Insert(T data);
        void Update(T data);
        void Delete(T data);
    }
}
