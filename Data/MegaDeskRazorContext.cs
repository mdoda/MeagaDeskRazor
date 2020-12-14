using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MegaDeskRazor;

namespace MegaDeskRazor.Data
{
    public class MegaDeskRazorContext : DbContext
    {
        public MegaDeskRazorContext (DbContextOptions<MegaDeskRazorContext> options)
            : base(options)
        {
        }

        public DbSet<MegaDeskRazor.DeskQuote> DeskQuote { get; set; }
        public DbSet<MegaDeskRazor.Desk> Desk { get; set; }
        public DbSet<MegaDeskRazor.DesktopMaterial> DesktopMaterial { get; set; }
        public DbSet<MegaDeskRazor.Delivery> Delivery { get; set; }

    }
}
