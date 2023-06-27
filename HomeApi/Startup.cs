using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using HomeApi.Configuration;
using HomeApi.Contracts;
using HomeApi.Contracts.Validators;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace HomeApi
{
	public class Startup
	{
		private IConfiguration Configuration { get; } = new ConfigurationBuilder()
			.AddJsonFile("appsettings.json")
			.AddJsonFile("appsettings.Development.json")
			.AddJsonFile("HomeOptions.json")
			.Build();

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddValidatorsFromAssemblyContaining<AddDeviceRequestValidator>();
			services.Configure<HomeOptions>(Configuration);
			services.AddControllers();
			var assembly = Assembly.GetAssembly(typeof(MappingProfile));
			services.AddAutoMapper(assembly);
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "HomeApi", Version = "v1" });
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HomeApi v1"));
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
