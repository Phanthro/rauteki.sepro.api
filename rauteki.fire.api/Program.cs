using MediatR;
using DA = DataAccess;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Rauteki.Fire.Api.Repositories.Interfaces;
using Rauteki.Fire.Api.Repositories;
using Rauteki.Fire.Api.Misc.Extensions;
using Microsoft.AspNetCore.Mvc.Authorization;
using Rauteki.Fire.Api.Services.Interfaces;
using Rauteki.Fire.Api.Services;
using Microsoft.AspNetCore.Http.Json;
using System.Text.Json.Serialization;
using System.Globalization;

var cultureInfo = new CultureInfo("pt-BR");
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiVersioningConfigured();

builder.Services.AddSwaggerSwashbuckleConfigured();
builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("secrets/appsettings.json", optional: true);

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
    {
        builder
        // .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
        .SetIsOriginAllowed(origin => true)
        .AllowCredentials();
    }));


var services = builder.Services;

services /**/
    .AddHttpClient()
    .AddTransient<DA.IDataAccess, DA.DataAccess>()
    .AddTransient<IUsuarioRepository, UsuarioRepository>()
    .AddTransient<IClienteRepository, ClienteRepository>()
    .AddTransient<IConsultaRepository, ConsultaRepository>()
    .AddTransient<IDominioRepository, DominioRepository>()
    .AddTransient<IFireService, FireService>()
    ;

services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
services.AddMediatR(typeof(Program));
services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.ConfiguraBearer(builder.Configuration);
services.AddControllers(x => x.Filters.Add(new AuthorizeFilter()))
.AddJsonOptions(opcoes =>
            {
                opcoes.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            });

services.Configure<CookiePolicyOptions>(options =>
{
    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
});


var app = builder.Build();
app.UseCors("corsapp");

app.UseSwagger();

var descriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
app.UseSwaggerUI(c =>
        {
            foreach (var description in descriptionProvider.ApiVersionDescriptions)
            {
                c.SwaggerEndpoint($"{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
            }
        });

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
