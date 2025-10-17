using SampleCoreBank.Core.Domain.CoreBank.Entities;

namespace SampleCoreBank.Tests.Helpers.Data.CoreBank.DataCollections
{
	public static class DesativacaoContasCollections
	{
		public static List<DesativacaoConta> GetDefaultCollection()
		{
			return new List<DesativacaoConta>()
			{
				new DesativacaoConta { DocumentoTitular	= "11223344556", Data = DateTime.Now.AddYears(-3), Responsavel = "Antônio Chagas" },
				new DesativacaoConta { DocumentoTitular = "44332211009", Data = DateTime.Now.AddYears(-1), Responsavel = "José Silveira" },
				new DesativacaoConta { DocumentoTitular = "33445566778", Data = DateTime.Now.AddYears(-8), Responsavel = "Carlos Andrade" },
			};
		}
	}
}
