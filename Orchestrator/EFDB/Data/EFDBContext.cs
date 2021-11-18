using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EFDB.Model;

namespace EFDB.Data
{
    public class EFDBContext : DbContext
    {
        public EFDBContext (DbContextOptions<EFDBContext> options)
            : base(options)
        {
        }

        public DbSet<EFDB.Model.SearchedResult> SearchedResult { get; set; }
    }
}
