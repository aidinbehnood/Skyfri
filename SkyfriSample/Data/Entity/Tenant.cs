using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SkyfriSample.Data.Entity
{
    public class Tenant
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid TenantId { get; set; }
        public string TenantName { get; set; }
        public ICollection<Portfolio>  Portfolios { get; set; }
    }
}
