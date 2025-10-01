using Lifty_WebApp.Business.Interfaces;
using Lifty_WebApp.Business.Models;
using Lifty_WebApp.DataAccess.Interfaces;

namespace Lifty_WebApp.Business.Services
{
    internal class ItemService : IItemService
    {
        public Task<ItemModel> CreateAsync(ItemModel model)
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

        public Task UpdateAsync(ItemModel model)
        {
            throw new NotImplementedException();
        }
    }
}
