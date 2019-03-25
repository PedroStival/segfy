using Insurance.Domain.Entities;
using Insurance.Domain.Interfaces.Repository;
using Insurance.Infra.Data;
using Insurance.Infra.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Infra.Repositories
{

    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(AppDataContext context) : base(context)
        {
        }
    }
}
