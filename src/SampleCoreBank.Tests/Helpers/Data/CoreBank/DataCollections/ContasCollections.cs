using SampleCoreBank.Core.Domain.CoreBank.Entities;

namespace SampleCoreBank.Tests.Helpers.Data.CoreBank.DataCollections
{
	public static class ContasCollections
	{
		public static List<Conta> GetDefaultCollection()
		{
			return new List<Conta>
			{
				new Conta
				{
					NomeTitular = "João Silva",
					DocumentoTitular = "12345678901",
					Saldo = 1000.00m,
					DataAbertura = DateTime.Now.AddYears(-2)
				},
				new Conta
				{
					NomeTitular = "Maria Oliveira",
					DocumentoTitular = "10987654321",
					Saldo = 2500.50m,
					DataAbertura = DateTime.Now.AddYears(-1)
				},
				new Conta
				{
					NomeTitular = "Carlos Pereira",
					DocumentoTitular = "11223344556",
					Saldo = 500.75m,
					DataAbertura = DateTime.Now.AddMonths(-6)
				},
				new Conta
				{
					NomeTitular = "Ana Costa",
					DocumentoTitular = "66554433221",
					Saldo = 3000.00m,
					DataAbertura = DateTime.Now.AddYears(-3)
				},
				new Conta
				{
					NomeTitular = "Pedro Santos",
					DocumentoTitular = "99887766554",
					Saldo = 150.25m,
					DataAbertura = DateTime.Now.AddMonths(-3)
				},
				new Conta
				{
					NomeTitular = "Luiza Fernandes",
					DocumentoTitular = "44332211009",
					Saldo = 750.00m,
					DataAbertura = DateTime.Now.AddYears(-4)
				},
				new Conta
				{
					NomeTitular = "Rafael Gomes",
					DocumentoTitular = "55667788990",
					Saldo = 1200.00m,
					DataAbertura = DateTime.Now.AddMonths(-8)
				},
				new Conta
				{
					NomeTitular = "Beatriz Almeida",
					DocumentoTitular = "22110033445",
					Saldo = 2000.00m,
					DataAbertura = DateTime.Now.AddYears(-5)
				},
				new Conta
				{
					NomeTitular = "Felipe Rocha",
					DocumentoTitular = "33445566778",
					Saldo = 950.00m,
					DataAbertura = DateTime.Now.AddMonths(-10)
				},
			};
		}
	}
}
