using SampleCoreBank.Core.Domain.CoreBank.Entities;

namespace SampleCoreBank.Tests.Helpers.Data.CoreBank.DataCollections
{
	public static class MovimentacoesCollections
	{
		public static List<Movimentacao> GetDefaultCollection()
		{
			return new List<Movimentacao>()
			{
				new Movimentacao() { DocumentoTitularDebitado = "12345678901", DocumentoTitularCreditado = "10987654321", DataOperacao = DateTime.Now.AddDays(-1), Valor = 10 },
				new Movimentacao() { DocumentoTitularDebitado = "66554433221", DocumentoTitularCreditado = "12345678901", DataOperacao = DateTime.Now.AddDays(-2), Valor = 10 },
				new Movimentacao() { DocumentoTitularDebitado = "12345678901", DocumentoTitularCreditado = "22110033445", DataOperacao = DateTime.Now.AddDays(-3), Valor = 10 },
				new Movimentacao() { DocumentoTitularDebitado = "12345678901", DocumentoTitularCreditado = "66554433221", DataOperacao = DateTime.Now.AddDays(-4), Valor = 10 },
				new Movimentacao() { DocumentoTitularDebitado = "66554433221", DocumentoTitularCreditado = "22110033445", DataOperacao = DateTime.Now.AddDays(-5), Valor = 10 },
				new Movimentacao() { DocumentoTitularDebitado = "55667788990", DocumentoTitularCreditado = "10987654321", DataOperacao = DateTime.Now.AddDays(-6), Valor = 10 },
				new Movimentacao() { DocumentoTitularDebitado = "10987654321", DocumentoTitularCreditado = "66554433221", DataOperacao = DateTime.Now.AddDays(-7), Valor = 10 },
				new Movimentacao() { DocumentoTitularDebitado = "22110033445", DocumentoTitularCreditado = "55667788990", DataOperacao = DateTime.Now.AddDays(-8), Valor = 10 },
				new Movimentacao() { DocumentoTitularDebitado = "10987654321", DocumentoTitularCreditado = "12345678901", DataOperacao = DateTime.Now.AddDays(-9), Valor = 10 },
				new Movimentacao() { DocumentoTitularDebitado = "55667788990", DocumentoTitularCreditado = "12345678901", DataOperacao = DateTime.Now.AddDays(-10), Valor = 10 },

			};
		}
	}
}
