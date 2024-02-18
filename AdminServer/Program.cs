using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using NLog;
using NLog.Web;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Entity;
using Core.Security;
using AdminServer.Middlewares;

var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
GlobalDiagnosticsContext.Set("basedir", WebHostDefaults.ContentRootKey);
logger.Debug("init main");
try
{
    var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddControllers();
    builder.Services.AddMvc();
    builder.Services.AddDbContext<EntityContext>(options => options
            .UseSqlServer(builder.Configuration.GetConnectionString("DBConnection")));

    #region TokenManagement
    builder.Services.Configure<TokenManagement>(builder.Configuration.GetSection("TokenManagement"));
    var token = builder.Configuration.GetSection("TokenManagement").Get<TokenManagement>();
    var secret = Encoding.ASCII.GetBytes(token?.Secret!);

    builder.Services.AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(x =>
    {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(token?.Secret!)),
            ValidIssuer = token?.Issuer,
            ValidAudience = token?.Audience,
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });
    #endregion

    #region MongoDatabase
    builder.Services.Configure<MongoDiagnosis.MongoDatabaseSettings>(
                    builder.Configuration.GetSection(nameof(MongoDiagnosis.MongoDatabaseSettings)));

    builder.Services.AddSingleton<MongoDiagnosis.IMongoDatabaseSettings>(sp =>
        sp.GetRequiredService<IOptions<MongoDiagnosis.MongoDatabaseSettings>>().Value);

    builder.Services.AddSingleton<IMongoClient>(s =>
            new MongoClient(builder.Configuration.GetValue<string>("MongoDatabaseSettings:ConnectionString")));
    #endregion

    #region MapperConfiguration
    var mappingConfig = new MapperConfiguration(mc =>
    {
        mc.AddProfile(new MappingProfile());
    });

    IMapper mapper = mappingConfig.CreateMapper();
    builder.Services.AddSingleton(mapper);
    #endregion

    #region Swagger
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "Admin Server-ContentPlus - 0.0.0",
            Description = "Last Update: 06-February-2024",
            Version = "v1"
        });
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please insert JWT with Bearer into field",
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey
        });
        c.AddSecurityRequirement(new OpenApiSecurityRequirement {
   {
     new OpenApiSecurityScheme
     {
       Reference = new OpenApiReference
       {
         Type = ReferenceType.SecurityScheme,
         Id = "Bearer"
       }
      },
      Array.Empty<string>()
    }
          });
    });
    #endregion

    builder.Services.AddHttpContextAccessor();
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();
    builder.Services.AddDIService();

    var app = builder.Build();

    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHttpsRedirection();
    app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
    app.UseRouting();
    app.UseAuthentication();
    app.UseAuthorization();
    app.UseStaticFiles();
    app.MapControllers();
    app.Run();
}
catch (Exception ex)
{
    logger.Error(ex, "Stopped program because of exception");
}
finally
{
    LogManager.Shutdown();
}