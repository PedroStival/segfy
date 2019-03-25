using Insurance.Domain.Interfaces;
using Insurance.Domain.Interfaces.Repository;
using Insurance.Infra.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Infra.Data
{
    public class Context : IContext
    {
        public readonly AppDataContext _context;
        public Context()
        {
            _context = new AppDataContext();
            Seguros = new SeguroRepository(_context);
            Produtos = new ProdutoRepository(_context);
            ProdutoTipos = new ProdutoTipoRepository(_context);

        }
        public ISeguroRepository Seguros { get; private set; }
        public IProdutoRepository Produtos { get; private set; }
        public IProdutoTipoRepository ProdutoTipos { get; private set; }
        public void LazyLoadOn()
        {
            _context.Configuration.LazyLoadingEnabled = true;
        }
        public int Save()
        {
            return _context.SaveChanges();
        }

        public Task<int> SaveAsync()
        {
            return _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
