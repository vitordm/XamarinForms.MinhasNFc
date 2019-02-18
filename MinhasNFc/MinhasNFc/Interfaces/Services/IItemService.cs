using MinhasNFc.Models;

namespace MinhasNFc.Interfaces.Services
{
    public interface IItemService : IStoreService<Item>
    {
        void Sincronizar(Item item);
    }
}
