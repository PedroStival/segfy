using Insurance.Domain.Entities;
using Insurance.Domain.Interfaces.Repository;
using Insurance.Infra.Data;
using Insurance.Infra.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Infra.Repositories
{

    public class SeguroRepository : Repository<Seguro>, ISeguroRepository
    {
        private readonly AppDataContext _context;
        public SeguroRepository(AppDataContext context) : base(context)
        {
            _context = context;
        }

        public override void Add(Seguro entity)
        {
            _context.Entry(entity.ProdutoTipo).State = EntityState.Unchanged;
            base.Add(entity);
        }

    }

}
