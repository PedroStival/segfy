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
    public class SeguroService : ISeguroService
    {

        public void Add(Seguro entity)
        {
            var fiscal = new EntityValidation(entity);

            if (!fiscal.Valid())
            {
                throw new Exception(fiscal.GetErrorMessage());
            }
            using (Context context = new Context())
            {
                context.Seguros.Add(entity);
                context.Save();
            }
        }

        public IEnumerable<Seguro> All()
        {
            IEnumerable<Seguro> seguros;
            using (var context = new Context())
            {
                seguros = context.Seguros.All();
                seguros = context.Seguros.Include(seguros, x => x.Produto, x => x.ProdutoTipo);
            }
            return seguros;
        }

        public void Delete(Seguro entity)
        {
            using (Context context = new Context())
            {
                context.Seguros.Delete(entity);
                context.Save();
            }
        }

        public void Dispose()
        {

        }

        public Seguro Get(long id)
        {
            Seguro seguro;
            using (var context = new Context())
            {
                seguro = context.Seguros.Get(id);
                seguro = context.Seguros.Include(seguro, x => x.Produto, x => x.ProdutoTipo);
            }
            return seguro;
        }

        public Seguro SearchPlaca(string placa)
        {
            if (placa.Length == 7)
            {
                placa = $"{placa.Substring(0, 3)}-{placa.Substring(3)}";
            }
            Seguro seguro;
            using (var context = new Context())
            {
                seguro = context.Seguros.Find(x => x.ProdutoTipoId == (int)ProdutoTipoEnum.Automovel && x.Produto.Descricao.Equals(placa)).FirstOrDefault();
                seguro = context.Seguros.Include(seguro, x => x.Produto, x => x.ProdutoTipo);
            }
            return seguro;
        }

        public void Update(Seguro entity)
        {
            var fiscal = new EntityValidation(entity);

            if (!fiscal.Valid())
            {
                throw new Exception(fiscal.GetErrorMessage());
            }
            using (Context context = new Context())
            {
                entity.ProdutoTipoId = entity.ProdutoTipo.Id;
                context.Produtos.Update(entity.Produto);
                context.Seguros.Update(entity);
                context.Save();
            }
        }
    }
}
