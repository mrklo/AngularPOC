using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MM3Poc.Models;

namespace MM3Poc.Data
{
    public class MM3PocContext : DbContext
    {
        public MM3PocContext (DbContextOptions<MM3PocContext> options)
            : base(options)
        {
        }

        public DbSet<MM3Poc.Models.Person> Person { get; set; }
    }
}
