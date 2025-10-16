using System.Linq.Expressions;
using SampleCoreBank.Core.Domain.CoreBank.Entities;
using SampleCoreBank.Core.Domain.CoreBank.Interfaces.Infrastructures.Data;
using SampleCoreBank.Shared.Abstractions.Domain.Specifications;

namespace SampleCoreBank.Core.Domain.CoreBank.Abstractions.Specifications
{
    public class MovimetacaoVerificaSaldoContaDebitadaSpecification : Specification<Movimentacao>
    {
        private ICoreBankDbContextReader Reader { get; set; }
        public MovimetacaoVerificaSaldoContaDebitadaSpecification(ICoreBankDbContextReader reader)
        {
            Reader = reader;
            SpecificationMessage = "Saldo da conta debitada é insuficiente!";
        }

        public override Expression<Func<Movimentacao, bool>> ToExpression()
        {
            return movimentacao => Reader.Query<Conta>().Any(db =>
                db.DocumentoTitular == movimentacao.DocumentoTitularDebitado && db.Saldo >= movimentacao.Valor
            );
        }
    }
}