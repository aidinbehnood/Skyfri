using Microsoft.EntityFrameworkCore;
using SkyfriSample.Contract.Repository;
using SkyfriSample.Data.Entity;
using SkyfriSample.Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkyfriSample.Data.Repository
{

    public class TenantRepository : ITenantRepository
    {
        private readonly SkyfriContext context;
        public TenantRepository(SkyfriContext context)
        {
            this.context = context;
        }

        public  void Delete(string Name)
        {
            var model=  context.Tenants.Where(c => c.TenantName == Name).FirstOrDefault();
            context.Tenants.Remove(model);
        }

        public async Task<List<Tenant>> GetAllTenant()
        {
            return await context.Tenants.ToListAsync();
        }

        public async Task<Tenant> GetTenant(string Name)
        {
            var model = await context.Tenants.Where(c => c.TenantName == Name).FirstOrDefaultAsync();
            return model;
        }


        public async void Insert(Tenant model)
        {
           await context.AddAsync(model);
        }

        public async Task<bool> SaveChange()
        {
            return await context.SaveChangesAsync() > 0;
        }


        public void UpdateTenant(Tenant model)
        {
            context.Update(model);
        }

       
    }
}
