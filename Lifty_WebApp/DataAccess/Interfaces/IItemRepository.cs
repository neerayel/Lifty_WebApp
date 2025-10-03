using Lifty_WebApp.DataAccess.Entities;

namespace Lifty_WebApp.DataAccess.Interfaces
{
    public interface IItemRepository : IRepository<Item>
    {
        Task<List<Item>> GetAllByRequestAsync(string request);
        Task<Item> GetByIdAsync(int testId);
        Task<List<Item>> GetAllAsync();
        Task<List<Item>> GetAllByPageNumberAsync(int pageNumber, int count);
        Task<Item> CopyByIdAsync(int oldTestId);
        Task<bool> CheckPublishAsync(Item itemModel);
    }
}
