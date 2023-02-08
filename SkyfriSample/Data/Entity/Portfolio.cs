using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SkyfriSample.Data.Entity
{
    public class Portfolio
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PortfolioId { get; set; }
        public Guid TenantId { get; set; }
        public string PortfolioName { get; set; }
        public Tenant Tenant  { get; set; }
    }
}
