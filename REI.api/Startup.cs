using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using REIFinal.Core.Common;
using REIFinal.Core.Repository;
using REIFinal.Core.Service;
using REIFinal.Infra.Common;
using REIFinal.Infra.Repository;
using REIFinal.Infra.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REI.api
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
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(y =>
            {
                y.RequireHttpsMetadata = false;
                y.SaveToken = true;
                y.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("[SECRET USED TO SIGN AND VERIFY JWT TOKENS, IT CAN BE ANY STRING]")),
                    ValidateIssuer = false,
                    ValidateAudience = false

                };
            });
            
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<ILoginReopsitory, LoginRepository>();
            services.AddScoped<IDBContext, DBContext>();
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IAdvertisementService, AdvertisementService>();
            services.AddScoped<IAdvertisementRepository, AdvertisementRepository>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IContactUsService, ContactUsService>();
            services.AddScoped<IContactUsRepository, ContactUsRepository>();
            services.AddScoped<IFavoritAdvService, FavoritAdvService>();
            services.AddScoped<IFavoritAdvRepository, FavoritAdvRepository>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IRentContractsService, RentContractsService>();
            services.AddScoped<IRentContractsRepository, RentContractsRepository>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<ISaleContractsService, SaleContractsService>();
            services.AddScoped<ISaleContractsRepository, SaleContractsRepository>();
            services.AddScoped<ITestimonialService, TestimonialService>();
            services.AddScoped<ITestimonialRepository, TestimonialRepository>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
