using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using SampleCoreBank.Middleware;
using System.Reflection;
using SampleCoreBank.Presentations.WebAPI.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace SampleCoreBank.Tests
{
	public class TestStartup
	{
		public TestStartup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			var assembly = typeof(TestStartup).GetTypeInfo().Assembly;

			services.AddMiddlewareTest(Configuration, assembly);

			services.AddControllers().AddApplicationPart(typeof(ContasController).Assembly);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.UseHttpsRedirection();

			app.UseMiddlewareTest();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
