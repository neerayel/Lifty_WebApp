using Lifty_WebApp.DataAccess.Entities;

namespace Lifty_WebApp.DataAccess.Interfaces
{
    public interface IContactsRepository
    {
        Task<ContactsModel> GetDataAsync();
        Task UpdateAsync(ContactsModel contacts);
    }
}
