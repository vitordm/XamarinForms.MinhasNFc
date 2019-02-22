using MinhasNFc.Models;
using System.Threading.Tasks;

namespace MinhasNFc.Interfaces.Services
{
    public interface IItemService : IStoreService<Item>
    {
        Task Sincronizar(Item item);
    }
}
