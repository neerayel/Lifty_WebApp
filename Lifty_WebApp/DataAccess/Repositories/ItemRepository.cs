using Lifty_WebApp.DataAccess.Entities;
using Lifty_WebApp.DataAccess.Interfaces;

namespace Lifty_WebApp.DataAccess.Repositories
{
    internal class ItemRepository : IItemRepository
    {
        public Task<bool> CheckPublishAsync(Item itemModel)
        {
            throw new NotImplementedException();
        }

        public Task<Item> CopyByIdAsync(int oldTestId)
        {
            throw new NotImplementedException();
        }

        public Task<Item> CreateAsync(Item item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteManyAsync(List<int> ids)
        {
            throw new NotImplementedException();
        }

        public Task<List<Item>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Item>> GetAllByPageNumberAsync(int pageNumber, int count)
        {
            throw new NotImplementedException();
        }

        public Task<List<Item>> GetAllByRequestAsync(string request)
        {
            throw new NotImplementedException();
        }

        public Task<Item> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Item item)
        {
            throw new NotImplementedException();
        }
    }
}
