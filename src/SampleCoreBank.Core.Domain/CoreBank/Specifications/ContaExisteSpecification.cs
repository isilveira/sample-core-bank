using System.Linq.Expressions;
using SampleCoreBank.Core.Domain.CoreBank.Entities;
using SampleCoreBank.Core.Domain.CoreBank.Interfaces.Infrastructures.Data;
using SampleCoreBank.Shared.Abstractions.Domain.Specifications;

namespace SampleCoreBank.Core.Domain.CoreBank.Specifications
{
    public class ContaExisteSpecification : Specification<DesativacaoConta>
    {
        private ICoreBankDbContextReader Reader { get; set; }
        public ContaExisteSpecification(ICoreBankDbContextReader reader)
        {
            Reader = reader;
            SpecificationMessage = "Conta inválida!";
        }

        public override Expression<Func<DesativacaoConta, bool>> ToExpression()
        {
            return desativacaoConta => Reader.Query<Conta>().Any(db =>
                db.DocumentoTitular == desativacaoConta.DocumentoTitular
            );
        }
    }
}