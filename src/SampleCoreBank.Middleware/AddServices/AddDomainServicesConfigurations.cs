using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleCoreBank.Middleware.AddServices
{
	public static class AddDomainServicesConfigurations
	{
		public static IServiceCollection AddDomainServices(this IServiceCollection services)
		{
			return services;
		}
	}
}
