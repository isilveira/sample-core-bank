using System.Linq.Expressions;
using SampleCoreBank.Core.Domain.CoreBank.Entities;
using SampleCoreBank.Core.Domain.CoreBank.Interfaces.Infrastructures.Data;
using SampleCoreBank.Shared.Abstractions.Domain.Specifications;

namespace SampleCoreBank.Core.Domain.CoreBank.Specifications
{
    public class MovimetacaoContaCreditadaEhAtivaSpecification : Specification<Movimentacao>
    {
        private ICoreBankDbContextReader Reader { get; set; }
        public MovimetacaoContaCreditadaEhAtivaSpecification(ICoreBankDbContextReader reader)
        {
            Reader = reader;
            SpecificationMessage = "Conta creditada é inativa!";
        }

        public override Expression<Func<Movimentacao, bool>> ToExpression()
		{
			return movimentacao => CheckRule(movimentacao);
		}

		private bool CheckRule(Movimentacao movimentacao)
		{
			var contaExiste = Reader.Query<Conta>().Any(db => db.DocumentoTitular == movimentacao.DocumentoTitularCreditado);
            var contaAtiva = !Reader.Query<DesativacaoConta>().Any(db => db.DocumentoTitular == movimentacao.DocumentoTitularCreditado);

            return contaExiste && contaAtiva;
		}
	}
}