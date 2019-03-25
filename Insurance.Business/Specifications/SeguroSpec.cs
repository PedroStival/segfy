using System.Collections.Generic;
using System.Linq;
using Insurance.Business.Validations;
using Insurance.Domain.Entities;
using Insurance.Domain.Interfaces.Specification;
using Insurance.Infra.Data;

namespace Insurance.Business.Specifications
{
    public class SeguroSpec : ISpecification<Seguro>
    {
        public SeguroSpec()
        {
            ErrorMessages = new List<string>();
        }
        public List<string> ErrorMessages { get; private set; }


        public bool IsSatisfiedBy(Seguro entity)
        {
            var valid = true;

            if (string.IsNullOrEmpty(entity.Cpf) || (entity.Cpf.Length != 11 && entity.Cpf.Length != 14))
            {
                ErrorMessages.Add("Campo CPF/CNPJ não contem um documento válido");
                valid = false;
            }

            if (entity.Cpf.Length == 11)
            {
                if (!EntityValidation.IsCpf(entity.Cpf))
                {
                    ErrorMessages.Add("CPF do seguro é inválido");
                    valid = false;
                }
            }

            if (entity.Cpf.Length == 14)
            {
                if (!EntityValidation.IsCnpj(entity.Cpf))
                {
                    ErrorMessages.Add("CNPJ do seguro é inválido");
                    valid = false;
                }
            }

            if (entity.ProdutoTipo == null )
            {
                ErrorMessages.Add("Tipo do seguro precisa ser preenchido");
                valid = false;
            }

            if (entity.ProdutoTipo.Id == (int)ProdutoTipoEnum.Vida)
            {

                if (!EntityValidation.IsCpf(entity.Produto.Descricao))
                {
                    ErrorMessages.Add("CPF do segurado é inválido");
                    valid = false;
                }

            }
            if (entity.ProdutoTipo.Id == (int)ProdutoTipoEnum.Automovel)
            {
                if (entity.Produto.Descricao.Length == 7)
                {
                    entity.Produto.Descricao = $"{entity.Produto.Descricao.Substring(0, 3)}-{entity.Produto.Descricao.Substring(3)}";
                }

                if (!EntityValidation.IsPlaca(entity.Produto.Descricao))
                {
                    ErrorMessages.Add("Placa do veículo inválido");
                    valid = false;
                }
            }
            if (entity.ProdutoTipo.Id == (int)ProdutoTipoEnum.Residencial)
            {
                if (string.IsNullOrEmpty(entity.Produto.Descricao))
                {
                    ErrorMessages.Add("Endereço vazio");
                    valid = false;
                }
            }
            return valid;
        }



    }
}
