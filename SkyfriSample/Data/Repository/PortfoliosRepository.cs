using Microsoft.EntityFrameworkCore;
using SkyfriSample.Contract.Repository;
using SkyfriSample.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkyfriSample.Data.Repository
{
    public class PortfoliosRepository : IPortfolioRepository
    {
        private readonly SkyfriContext context;
        public PortfoliosRepository(SkyfriContext context)
        {
            this.context = context;
        }
        public void Delete(Guid portfolioId)
        {
            var model = context.Portfolios.Where(c => c.PortfolioId == portfolioId).FirstOrDefault();
            context.Portfolios.Remove(model);
        }

        public async Task<List<Portfolio>> Get(Guid Id)
        {
            return await context.Portfolios.Where(x => x.TenantId == Id).ToListAsync();
        }

        public async void Insert(Portfolio model)
        {
            await context.AddAsync(model);
        }

        public async Task<bool> SaveChange()
        {
            return await context.SaveChangesAsync() > 0;
        }

        public void Update(Portfolio model)
        {
            throw new NotImplementedException();
        }
    }
}
