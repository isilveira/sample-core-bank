using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SampleCoreBank.Core.Domain.CoreBank.Interfaces.Infrastructures.Data;
using SampleCoreBank.Infrastructures.Data.CoreBank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleCoreBank.Middleware.AddServices
{
	public static class AddDbContextConfigurations
	{
		public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddTransient<ICoreBankDbContextWriter, CoreBankDbContextWriter>();
			services.AddTransient<ICoreBankDbContextReader, CoreBankDbContextReader>();

			services.AddDbContext<CoreBankDbContext>(options =>
				options.UseSqlServer(
					configuration.GetConnectionString("DefaultConnection"),
					sql =>
					{
						sql.MigrationsAssembly(typeof(CoreBankDbContext).Assembly.GetName().Name);
						sql.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
					}));

			return services;
		}
		public static IServiceCollection AddDbContextsTest(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<CoreBankDbContext>(options =>
				options.UseInMemoryDatabase(nameof(CoreBankDbContext), new InMemoryDatabaseRoot()),
				ServiceLifetime.Singleton);
			
			services.AddTransient<ICoreBankDbContextWriter, CoreBankDbContextWriter>();
			services.AddTransient<ICoreBankDbContextReader, CoreBankDbContextReader>();

			return services;
		}
	}
}