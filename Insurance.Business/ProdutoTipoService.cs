using Insurance.Business.Validations;
using Insurance.Domain.Entities;
using Insurance.Domain.Interfaces.Repository;
using Insurance.Domain.Interfaces.Services;
using Insurance.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Insurance.Business
{
    public class ProdutoTipoService : IProdutoTipoService
    {

        public void Add(ProdutoTipo entity)
        {

        }

        public IEnumerable<ProdutoTipo> All()
        {
            IEnumerable<ProdutoTipo> tipos;
            using (var context = new Context())
            {
                tipos = context.ProdutoTipos.All();
            }
            return tipos;
        }

        public void Delete(ProdutoTipo entity)
        {
            using (Context context = new Context())
            {
                context.ProdutoTipos.Delete(entity);
                context.Save();
            }
        }

        public void Dispose()
        {

        }

        public ProdutoTipo Get(long id)
        {
            ProdutoTipo tipo;
            using (var context = new Context())
            {
                tipo = context.ProdutoTipos.Get(id);
            }
            return tipo;
        }

        public void Update(ProdutoTipo entity)
        {
       
        }
    }
}
