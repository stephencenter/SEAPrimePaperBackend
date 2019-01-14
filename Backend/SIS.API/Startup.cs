using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using PrimePaper.API.MappingProfiles;
using PrimePaper.Business.DataContract.Authorization;
using PrimePaper.Business.DataContract.Cart;
using PrimePaper.Business.DataContract.Contact.Interfaces;
using PrimePaper.Business.DataContract.Product;
using PrimePaper.Business.Managers;
using PrimePaper.Database.Contexts;
using PrimePaper.Database.DataContract.Application;
using PrimePaper.Database.DataContract.Authorization;
using PrimePaper.Database.DataContract.Cart;
using PrimePaper.Database.DataContract.Product;
using PrimePaper.Database.DataContract.Roles;
using PrimePaper.Database.Entities;
using PrimePaper.Database.Repositories;
using PrimePaper.Database.SeedData;
using Swashbuckle.AspNetCore.Swagger;
using System.Net;
using System.Text;

namespace PrimePaper.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SISContext>(x => x.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            IdentityBuilder builder = services.AddIdentityCore<UserEntity>(opt =>
                 {
                     opt.Password.RequireDigit = false;
                     opt.Password.RequiredLength = 4;
                     opt.Password.RequireNonAlphanumeric = false;
                     opt.Password.RequireUppercase = false;
                 });

            builder = new IdentityBuilder(builder.UserType, typeof(RoleEntity), builder.Services);
            builder.AddEntityFrameworkStores<SISContext>();
            builder.AddRoleValidator<RoleValidator<RoleEntity>>();
            builder.AddRoleManager<RoleManager<RoleEntity>>();
            builder.AddSignInManager<SignInManager<UserEntity>>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII
                            .GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            services.AddMvc(options =>
            {
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(opt =>
                {
                    opt.SerializerSettings.ReferenceLoopHandling =
                        Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });

            ////===== Cors =======
            services.AddCors();
            Mapper.Reset();
            //===== Mapping Config =======
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
                mc.AddProfile(new ContactMappingProfile());
                mc.AddProfile(new ProductMappingProfile());
                mc.AddProfile(new CartMappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddTransient<SeedRepository>();

            //===== Interfaces =======
            services.AddScoped<IAuthManager, AuthManager>();
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IContactManager, ContactManager>();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IProductManager, ProductManager>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICartManager, CartManager>();
            services.AddScoped<ICartRepository, CartRepository>();

            //======= Swagger =======
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "SIS API", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, SeedRepository seedRepo)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(builder =>
                {
                    builder.Run(async context =>
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                        var error = context.Features.Get<IExceptionHandlerFeature>();
                        if (error != null)
                        {
                            await context.Response.WriteAsync(error.Error.Message);
                        }
                    });
                });
                // app.UseHsts();
            }

            // app.UseHttpsRedirection();
            seedRepo.SeedUsers(); 
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            app.UseAuthentication();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SIS API V1");
            });
            app.UseMvc(routes =>
            {
                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Fallback", action = "Index" }
                );
            });

        }
    }
}
