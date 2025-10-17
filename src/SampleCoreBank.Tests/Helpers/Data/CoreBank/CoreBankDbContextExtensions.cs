using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using SampleCoreBank.Infrastructures.Data.CoreBank;

namespace SampleCoreBank.Tests.Helpers.Data.CoreBank
{
	public static class CoreBankDbContextExtensions
	{
		public static CoreBankDbContext GetInMemoryCoreBankDbContext()
		{
			var options = new DbContextOptionsBuilder<CoreBankDbContext>()
				.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
				.ConfigureWarnings(cw => cw.Ignore(InMemoryEventId.TransactionIgnoredWarning))
				.Options;
			var context = new CoreBankDbContext(options);

			context.Database.EnsureDeleted();
			context.Database.EnsureCreated();

			return context;
		}

		public static CoreBankDbContextReader GetDbContextReader(this CoreBankDbContext context)
		{
			return new CoreBankDbContextReader(context);
		}

		public static CoreBankDbContextWriter GetDbContextWriter(this CoreBankDbContext context)
		{
			return new CoreBankDbContextWriter(context);
		}

	}
}
