using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PierreAuthen.Models
{
    public class PierreAuthenContext : IdentityDbContext<ApplicationUser>
    {
        public virtual DbSet<Treat> Treats { get; set; }
        public virtual DbSet<Flavor> Flavors { get; set; }
        public virtual DbSet<TreatFlavor> TreatFlavors { get; set; }
        public PierreAuthenContext(DbContextOptions options) : base(options) {}
    }
}