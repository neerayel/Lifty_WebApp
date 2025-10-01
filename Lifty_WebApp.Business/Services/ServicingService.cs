using Lifty_WebApp.Business.Interfaces;
using Lifty_WebApp.Business.Models;
using Lifty_WebApp.DataAccess.Interfaces;

namespace Lifty_WebApp.Business.Services
{
    public class ServicingService : IServicingService
    {
        public Task<ServicingModel> CreateAsync(ServicingModel model)
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

        public Task UpdateAsync(ServicingModel model)
        {
            throw new NotImplementedException();
        }
    }
}
