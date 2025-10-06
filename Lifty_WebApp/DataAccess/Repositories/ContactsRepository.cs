using Lifty_WebApp.DataAccess.Entities;
using Lifty_WebApp.DataAccess.Interfaces;
using System.Text.Json;

namespace Lifty_WebApp.DataAccess.Repositories
{
    public class ContactsRepository : IContactsRepository
    {
        private readonly String itemDataPath = "Data/ContactsData.json";

        private async Task<ContactsModel> ReadJsonDataAsync()
        {
            await using FileStream openStream = File.OpenRead(itemDataPath);
            try
            {
                return await JsonSerializer.DeserializeAsync<ContactsModel>(openStream);
            }
            catch { return new ContactsModel(); }
        }
        private async Task WriteJsonDataAsync(ContactsModel contacts)
        {
            await using FileStream writeStream = File.Create(itemDataPath);
            await JsonSerializer.SerializeAsync<ContactsModel>(writeStream, contacts);
            writeStream.Close();
        }

        public async Task<ContactsModel> GetDataAsync()
        {
            return await ReadJsonDataAsync();
        }

        public async Task UpdateAsync(ContactsModel contacts)
        {
            await WriteJsonDataAsync(contacts);
        }
    }
}
