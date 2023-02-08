using SkyfriSample.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkyfriSample.Contract.Repository
{
    public interface IPortfolioRepository
    {
        void Insert(Portfolio model);
        Task<List<Portfolio>> Get(Guid TenantId);
        void Delete(Guid portfolioId );
        void Update(Portfolio model);
        Task<bool> SaveChange();
    }
}
