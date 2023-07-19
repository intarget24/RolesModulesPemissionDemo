using Microsoft.EntityFrameworkCore;
using RolesModulesPemissionDemo.Models;
using System.Reflection.Metadata;

namespace RolesModulesPemissionDemo.Database
{
    public class RolesAdministratorContext : DbContext
    {

        public DbSet<Rol> Rols { get; set; }
        public DbSet<Module> Modules { get; set; }

        public RolesAdministratorContext(DbContextOptions options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Module>()
                            .HasMany(e => e.Childs)
                            .WithOne(e => e.ParentModule)
                            .HasForeignKey(e => e.ModuleParentId)
                            .IsRequired(false);

        }

        protected RolesAdministratorContext()
        {

        }


    }
}
