using System.Collections.Generic;

namespace Insurance.Domain.Interfaces.Specification
{
    public interface ISpecification<in TEntity>
    {
        List<string> ErrorMessages { get; }
        bool IsSatisfiedBy(TEntity entity);
    }
}
