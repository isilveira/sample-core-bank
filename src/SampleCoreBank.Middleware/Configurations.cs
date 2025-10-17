using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SampleCoreBank.Middleware.AddServices;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace SampleCoreBank.Middleware
{
	public static class Configurations
	{
		public static IServiceCollection AddMiddleware(this IServiceCollection services, IConfiguration configuration, Assembly presentationAssembly)
		{
			services.AddLocalization();

			services.AddDbContexts(configuration);
			services.AddSpecifications();
			services.AddEntityValidations();
			services.AddDomainValidations();
			services.AddDomainServices();

			var assemblyApplication = AppDomain.CurrentDomain.Load("SampleCoreBank.Core.Application");
			var assemblyDomain = AppDomain.CurrentDomain.Load("SampleCoreBank.Core.Domain");
			
			services.AddMediatR(options => options.RegisterServicesFromAssemblies(assemblyApplication, assemblyDomain));
						
			services.AddSwaggerGen();

			// YOUR CODE GOES HERE
			return services;
		}

		public static IApplicationBuilder UseMiddleware(this IApplicationBuilder app)
		{
			var supportedCultures = new string[] { "en-US", "pt-BR" };

			var localizationOptions = new RequestLocalizationOptions()
				.SetDefaultCulture(supportedCultures[0])
				.AddSupportedCultures(supportedCultures)
				.AddSupportedUICultures(supportedCultures);

			app.UseRequestLocalization(localizationOptions);

			app.UseSwagger();
			app.UseSwaggerUI();

			//app.UseAuthentication();
			//app.UseAuthorization();
			// YOUR CODE GOES HERE
			return app;
		}
		#region TESTS
		public static IServiceCollection AddMiddlewareTest(this IServiceCollection services, IConfiguration configuration, Assembly presentationAssembly)
		{
			services.AddLocalization();

			services.AddDbContextsTest(configuration);
			services.AddSpecifications();
			services.AddEntityValidations();
			services.AddDomainValidations();
			services.AddDomainServices();

			var assemblyApplication = AppDomain.CurrentDomain.Load("Store.Core.Application");
			var assemblyDomain = AppDomain.CurrentDomain.Load("Store.Core.Domain");
			var assemblyInfrastructuresServices = AppDomain.CurrentDomain.Load("Store.Infrastructures.Services");
			services.AddMediatR(options => options.RegisterServicesFromAssemblies(assemblyApplication, assemblyDomain, assemblyInfrastructuresServices));

			// YOUR CODE GOES HERE
			return services;
		}

		public static IApplicationBuilder UseMiddlewareTest(this IApplicationBuilder app)
		{
			var supportedCultures = new string[] { "en-US", "pt-BR" };

			var localizationOptions = new RequestLocalizationOptions()
				.SetDefaultCulture(supportedCultures[0])
				.AddSupportedCultures(supportedCultures)
				.AddSupportedUICultures(supportedCultures);

			app.UseRequestLocalization(localizationOptions);

			//app.UseAuthentication();
			//app.UseAuthorization();
			// YOUR CODE GOES HERE
			return app;
		}
		#endregion
	}
}
