using System.Linq.Expressions;
using SampleCoreBank.Core.Domain.CoreBank.Entities;
using SampleCoreBank.Core.Domain.CoreBank.Interfaces.Infrastructures.Data;
using SampleCoreBank.Shared.Abstractions.Domain.Specifications;

namespace SampleCoreBank.Core.Domain.CoreBank.Specifications
{
    public class NaoPermitirCadastrarContaComMesmoDocumentoSpecification : Specification<Conta>
    {
        private ICoreBankDbContextReader Reader { get; set; }
        public NaoPermitirCadastrarContaComMesmoDocumentoSpecification(ICoreBankDbContextReader reader)
        {
            Reader = reader;
            SpecificationMessage = "Não é permitido cadastrar mais de uma conta para o mesmo documento!";
        }

        public override Expression<Func<Conta, bool>> ToExpression()
        {
            return conta => Reader.Query<Conta>().Any(db =>
                db.DocumentoTitular == conta.DocumentoTitular
            );
        }
    }
}