using System;
using System.Collections.Generic;
using System.Text;

namespace Insurance.Domain.Entities.Common
{
    public abstract class EntityBase
    {
        public long Id { get; set; }
        public DateTime DtInsert { get; set; }
        public DateTime DtUpdate { get; set; }
    }
}
