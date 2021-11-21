using DFDS.Challange.Customer.Api.Extensions;
using DFDS.Challange.Customer.Business.Queries.ListOfCustomerByFilter;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DFDS.Challange.Customer.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddFluentValidation(); 
            services.AddMvc();
            services.AddMediatR(typeof(Handler).GetTypeInfo().Assembly);
            services.AddEfTemplateContext();

            services.AddTransient<IValidator<Business.Commands.CreateCustomer.Request>, Business.Commands.CreateCustomer.RequestValidator>();
            services.AddTransient<IValidator<Business.Commands.UpdateCustomer.Request>, Business.Commands.UpdateCustomer.RequestValidator>();
            services.AddTransient<IValidator<Business.Commands.DeleteCustomer.Request>, Business.Commands.DeleteCustomer.RequestValidator>();

            services.AddSwaggerDocumentation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public virtual void Configure(IApplicationBuilder app)
        {
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwaggerDocumentation();
        }
    }
}
