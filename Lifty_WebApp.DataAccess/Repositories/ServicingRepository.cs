using Lifty_WebApp.DataAccess.Entities;
using Lifty_WebApp.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lifty_WebApp.DataAccess.Repositories
{
    internal class ServicingRepository : IServicingRepository
    {
        public Task<Servicing> CreateAsync(Servicing item)
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

        public Task<List<Servicing>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Servicing> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Servicing item)
        {
            throw new NotImplementedException();
        }
    }
}
