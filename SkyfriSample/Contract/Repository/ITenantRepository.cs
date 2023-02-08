using SkyfriSample.Data.Entity;
using SkyfriSample.Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkyfriSample.Contract.Repository
{
    public interface ITenantRepository
    {
        void Insert(Tenant Model);
        Task<Tenant> GetTenant(string Id);
        Task<List<Tenant>> GetAllTenant();
        void Delete(string Name);
        void UpdateTenant(Tenant Model);
        Task<bool> SaveChange();
    }
}
