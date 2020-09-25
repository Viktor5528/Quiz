using AutoMapper;
using DataLayer;
using DataLayer.Entity;
using DataLayer.Repo;
using DataLayer.Repo.Interfaces;
using FluentValidation.AspNetCore;
using LegalActionPlatform.Account.Services.Implementation.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Services;
using Services.Interfaces;
using Services.Profiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz
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

            services.AddControllers(opt =>
            {
                // ...
            }).AddFluentValidation(fvc =>
            {
                fvc.RegisterValidatorsFromAssemblyContaining<Startup>();
                fvc.RunDefaultMvcValidationAfterFluentValidationExecutes = false;

            });
            services.AddCors();
            services.AddTransient<IUserRepo, UserRepo>();
            services.AddTransient<IAnswerRepo, AnswerRepo>();
            services.AddTransient<IQuizRepo, QuizRepo>();
            services.AddTransient<IQuestionRepo, QuestionRepo>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAnswerService, AnswerService>();
            services.AddTransient<IQuizService, QuizService>();
            services.AddTransient<IQuestionService, QuestionService>();
            services.AddTransient<ITokenService, JWTTokenService>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = "Issuer",

                        ValidateAudience = true,
                        ValidAudience = "Audience",

                        ValidateLifetime = true,

                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("qwertyqwertyqwertyqwertyqwerty")),
                        ValidateIssuerSigningKey = true
                    };
                    options.Events = new JwtBearerEvents
                    {

                    };
                });
            services.AddAutoMapper(typeof(UserProfile).Assembly);
            services.AddSwaggerGen(c =>
            {
                c.CustomOperationIds(d =>
                {
                    var x = (d.ActionDescriptor as ControllerActionDescriptor);
                    return x.ActionName + x.ControllerName;
                });
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Fixtures API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });
            });
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(Configuration.GetConnectionString("quizConnectionstring")));
            services.AddIdentity<User, IdentityRole<int>>(opt=> {
                opt.Password.RequiredLength = 5;   // минимальная длина
                opt.Password.RequireNonAlphanumeric = false;   // требуются ли не алфавитно-цифровые символы
                opt.Password.RequireLowercase = false; // требуются ли символы в нижнем регистре
                opt.Password.RequireUppercase = false; // требуются ли символы в верхнем регистре
                opt.Password.RequireDigit = false; // требуются ли цифры
            })
                .AddEntityFrameworkStores<ApplicationContext>();
            services.AddTransient<IUserStore<User>, UserRepo>();
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

            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseAuthentication();    
            app.UseAuthorization();
            app.UseSwagger(o => o.SerializeAsV2 = true);
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Fixture API");
                c.RoutePrefix = string.Empty;
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
        }
    }
}
