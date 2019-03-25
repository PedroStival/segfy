using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insurance.Domain.Entities;

namespace Insurance.Infra.Data
{
    class ContextInitializer : CreateDatabaseIfNotExists<AppDataContext>
    {
        protected override void Seed(AppDataContext context)
        {
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
