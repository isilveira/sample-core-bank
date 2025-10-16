using System.Linq.Expressions;
using SampleCoreBank.Core.Domain.CoreBank.Entities;
using SampleCoreBank.Core.Domain.CoreBank.Interfaces.Infrastructures.Data;
using SampleCoreBank.Shared.Abstractions.Domain.Specifications;

namespace SampleCoreBank.Core.Domain.CoreBank.Abstractions.Specifications
{
    public class MovimetacaoContaDebitadaEhValidaSpecification : Specification<Movimentacao>
    {
        private ICoreBankDbContextReader Reader { get; set; }
        public MovimetacaoContaDebitadaEhValidaSpecification(ICoreBankDbContextReader reader)
        {
            Reader = reader;
            SpecificationMessage = "Conta debitada é inválida!";
        }

        public override Expression<Func<Movimentacao, bool>> ToExpression()
        {
            return movimentacao => Reader.Query<Conta>().Any(db =>
                db.DocumentoTitular == movimentacao.DocumentoTitularDebitado
            );
        }
    }
}