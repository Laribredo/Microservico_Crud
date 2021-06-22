using Microservico_Crud.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservico_Crud.DBContexts
{
    public class CaseContext : DbContext
    {
        public CaseContext(DbContextOptions<CaseContext> options) : base(options)
        {
        }

        public DbSet<Case> Cases { get; set; }
    }
}
