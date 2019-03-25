using Insurance.Domain.Entities;
using Insurance.Infraestructure.Data.Map.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Infra.Data.Map
{
    public class SeguroMap : MapBase<Seguro>
    {
        public SeguroMap()
        {
            Property(x => x.Cpf).HasMaxLength(14);
        }
    }
}
