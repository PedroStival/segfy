using System.Collections.Generic;
using Insurance.Domain.Entities;

namespace Insurance.Infra.Migrations
{
    using Insurance.Infra.Data;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AppDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(AppDataContext context)
        {
            //  context.SaveChanges();

            IList<ProdutoTipo> produtoTipo = new List<ProdutoTipo>();

            produtoTipo.Add(new ProdutoTipo() { Tipo = "Vida" });
            produtoTipo.Add(new ProdutoTipo() { Tipo = "Residencial" });
            produtoTipo.Add(new ProdutoTipo() { Tipo = "Automovel" });

            context.ProdutoTipos.AddRange(produtoTipo);
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
