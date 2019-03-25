using Insurance.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Insurance.Domain.Entities
{
    public class Seguro : EntityBase
    {
        public string Cpf { get; set; }
        public long ProdutoTipoId { get; set; }
        [ForeignKey("ProdutoTipoId")]
        public virtual ProdutoTipo ProdutoTipo { get; set; }

        public long ProdutoId { get; set; }
        [ForeignKey("ProdutoId")]
        public virtual Produto Produto { get; set; }
    }
}
