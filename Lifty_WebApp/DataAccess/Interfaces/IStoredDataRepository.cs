using Lifty_WebApp.DataAccess.Entities;

namespace Lifty_WebApp.DataAccess.Interfaces
{
    public interface IStoredDataRepository
    {
        Task<ContactsModel> GetContactsDataAsync();
        Task UpdateContactsDataAsync(ContactsModel model);

        Task<AboutDataModel> GetAboutDataAsync();
        Task UpdateAboutDataAsync(AboutDataModel model);
    }
}
