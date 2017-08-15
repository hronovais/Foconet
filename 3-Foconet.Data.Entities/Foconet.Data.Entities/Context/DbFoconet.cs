using Foconet.Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foconet.Data.Entities.Context
{
    public class DbFoconet : DbContext
    {
        public DbFoconet() : base("DbFoconet")
        {
            this.Configuration.LazyLoadingEnabled = false;
            //Database.SetInitializer<DbFoconet>(null);
            //Database.SetInitializer(new DbMoneyInitializer());
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DbContext>());
            Database.SetInitializer(new CreateDatabaseIfNotExists<DbFoconet>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Material> Material { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<PedidoItens> PedidoItens { get; set; }
    }
}
 