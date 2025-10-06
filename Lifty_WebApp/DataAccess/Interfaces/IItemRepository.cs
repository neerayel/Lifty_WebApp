using Lifty_WebApp.DataAccess.Entities;

namespace Lifty_WebApp.DataAccess.Interfaces
{
    public interface IItemRepository : IRepository<ItemModel>
    {
        Task<List<ItemModel>> GetAllByRequestAsync(string request);
        Task<ItemModel> GetByIdAsync(string itemId);
        Task<List<ItemModel>> GetAllAsync();
        Task<ItemModel> CopyByIdAsync(string oldItemId);
    }
}
