using Lifty_WebApp.DataAccess.Entities;
using Lifty_WebApp.DataAccess.Interfaces;
using System.Text.Json;

namespace Lifty_WebApp.DataAccess.Repositories
{
    public class StoredDataRepository : IStoredDataRepository
    {
        private readonly String contactsDataPath = "Data/ContactsData.json";
        private readonly String aboutDataPath = "Data/AboutData.json";

        public async Task<ContactsModel> GetContactsDataAsync()
        {
            await using FileStream openStream = File.OpenRead(contactsDataPath);
            try
            {
                return await JsonSerializer.DeserializeAsync<ContactsModel>(openStream);
            }
            catch { return new ContactsModel() {    Email = "",
                                                    Number = "",
                                                    Address = "",
                                                    WorkTime = "",
                                                    YandexMapLink = ""
                                                };
            }
        }

        public async Task UpdateContactsDataAsync(ContactsModel model)
        {
            await using FileStream writeStream = File.Create(contactsDataPath);
            await JsonSerializer.SerializeAsync<ContactsModel>(writeStream, model);
            writeStream.Close();
        }


        public async Task<AboutDataModel> GetAboutDataAsync()
        {
            await using FileStream openStream = File.OpenRead(aboutDataPath);
            try
            {
                return await JsonSerializer.DeserializeAsync<AboutDataModel>(openStream);
            }
            catch
            {
                return new AboutDataModel() {   Description = "", 
                                                Achievements = new List<string>() { "" },
                                                Services = new List<string>() { "" },
                                                Collaborations = new List<string>() { "" } 
                                             };
            }
        }

        public async Task UpdateAboutDataAsync(AboutDataModel model)
        {
            await using FileStream writeStream = File.Create(aboutDataPath);
            await JsonSerializer.SerializeAsync<AboutDataModel>(writeStream, model);
            writeStream.Close();
        }

    }
}
