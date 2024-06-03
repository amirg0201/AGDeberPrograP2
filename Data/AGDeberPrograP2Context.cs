using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AGDeberPrograP2.Models;

namespace AGDeberPrograP2.Data
{
    public class AGDeberPrograP2Context : DbContext
    {
        public AGDeberPrograP2Context (DbContextOptions<AGDeberPrograP2Context> options)
            : base(options)
        {
        }

        public DbSet<AGDeberPrograP2.Models.AgAuto> AgAuto { get; set; } = default!;
    }
}
