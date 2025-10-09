using Lifty_WebApp.DataAccess.Entities;
using Lifty_WebApp.DataAccess.Interfaces;
using System.Text.Json;

namespace Lifty_WebApp.DataAccess.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly String itemDataPath = "Data/ItemData.json";

        private async Task<List<ItemModel>> ReadJsonDataAsync()
        {
            await using FileStream openStream = File.OpenRead(itemDataPath);
            try
            {
                return await JsonSerializer.DeserializeAsync<List<ItemModel>>(openStream);
            }
            catch { return new List<ItemModel>(); }
        }
        private async Task WriteJsonDataAsync(List<ItemModel> items)
        {
            await using FileStream writeStream = File.Create(itemDataPath);
            await JsonSerializer.SerializeAsync<List<ItemModel>>(writeStream, items);
            writeStream.Close();
        }

        public async Task<ItemModel> CopyByIdAsync(string oldItemId)
        {
            throw new NotImplementedException();
        }

        public async Task<ItemModel> CreateAsync(ItemModel item)
        {
            List<ItemModel> items = await ReadJsonDataAsync();
            item.Id = Guid.NewGuid().ToString();
            items.Add(item);
            await WriteJsonDataAsync(items);
            return item;
        }

        public async Task DeleteAsync(string id)
        {
            List<ItemModel> items = await ReadJsonDataAsync();
            try
            {
                items.Remove(items.FirstOrDefault(x => x.Id == id));
            }
            catch { }

            await WriteJsonDataAsync(items);
        }

        public async Task<List<ItemModel>> GetAllAsync()
        {
            return await ReadJsonDataAsync();
        }

        public async Task<List<ItemModel>> GetAllByRequestAsync(string request)
        {
            throw new NotImplementedException();
        }

        public async Task<ItemModel> GetByIdAsync(string id)
        {
            List<ItemModel> items = await ReadJsonDataAsync();
            return items.FirstOrDefault(x => x.Id == id);
        }

        public async Task UpdateAsync(ItemModel item)
        {
            List<ItemModel> items = await ReadJsonDataAsync();
            try
            {
                items[items.IndexOf(items.FirstOrDefault(x => x.Id == item.Id))] = item;
            }
            catch { }

            await WriteJsonDataAsync(items);
        }
    }
}
