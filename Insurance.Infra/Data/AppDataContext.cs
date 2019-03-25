using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SqlClient;
using System.Linq;
using Insurance.Domain.Entities;
using Insurance.Infra.Data.Map;
using Insurance.Infraestructure.Data.Map;

namespace Insurance.Infra.Data
{
    public class AppDataContext : DbContext
    {
        public DbSet<Seguro> Seguros { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<ProdutoTipo> ProdutoTipos { get; set; }

        public AppDataContext() : base("AppConnectionString")
        {
            //Database.SetInitializer<AppDataContext>(new ContextInitializer());
            //Database.SetInitializer<AppDataContext>(new ContextInitializerOfficial());

            //Configuration.ProxyCreationEnabled = false;
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<AppDataContext, Configuration>());
            Database.SetInitializer<AppDataContext>(new ContextInitializer());
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new SeguroMap());
        }

        public override int SaveChanges()
        {

            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DtInsert") != null))
            {
                entry.Property("DtUpdate").CurrentValue = DateTime.Now;

                if (entry.State == EntityState.Added)
                {
                    entry.Property("DtInsert").CurrentValue = DateTime.Now;
                }
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DtInsert").IsModified = false;
                }
            }

            return base.SaveChanges();
        }
    }
}
