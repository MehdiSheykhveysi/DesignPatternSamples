using SpecificationPattern.ApplicationServices.Specifications.Common;
using SpecificationPattern.Entities;
using System;
using System.Linq.Expressions;

namespace SpecificationPattern.ApplicationServices.Specifications
{
    public class NameSpecification : Specification<Person>
    {
        private readonly string Name;

        public NameSpecification(string name)
        {
            Name = name;
        }
        public override Expression<Func<Person, bool>> ToExpression()
        {
            return person => person.FirstName.Contains(Name, StringComparison.CurrentCultureIgnoreCase);
        }
    }
}
