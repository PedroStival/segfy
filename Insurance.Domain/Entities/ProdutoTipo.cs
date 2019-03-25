using Insurance.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Insurance.Domain.Entities
{

    public class ProdutoTipo : EntityBase
    {
        public string Tipo { get; set; }
    }

    public enum ProdutoTipoEnum
    {
        Vida = 1,
        Residencial = 2,
        Automovel = 3
    }
}
