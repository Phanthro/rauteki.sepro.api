using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Rauteki.Fire.Api.Misc.Extensions;
/// <summary>
/// Configures the Swagger generation options.
/// </summary>
/// <remarks>This allows API versioning to define a Swagger document per API version after the
/// <see cref="IApiVersionDescriptionProvider"/> service has been resolved from the service container.</remarks>
public class SwaggerSmashBuckleOptions : IConfigureOptions<SwaggerGenOptions>
{
    readonly IApiVersionDescriptionProvider provider;

    /// <summary>
    /// Initializes a new instance of the <see cref="ConfigureSwaggerGeneratorOptions"/> class.
    /// </summary>
    /// <param name="provider">The <see cref="IApiVersionDescriptionProvider">provider</see> used to generate Swagger documents.</param>
    public SwaggerSmashBuckleOptions(IApiVersionDescriptionProvider provider) => this.provider = provider;

    /// <inheritdoc />
    public void Configure(SwaggerGenOptions options)
    {
        foreach (var description in provider.ApiVersionDescriptions)
        {
            options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
        }
    }

    private static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
    {
        var info = new OpenApiInfo()
        {
            Title = "Rauteki/Fire - API Service - Documentação",
            Version = description.ApiVersion.ToString(),
            Description 
                = "WebApi Para operações relacionadas  " +
                  "\n- **Autenticação/Login** \n",
            Contact = new OpenApiContact() { Name = "Rauteki/Fire", Email = "	bruno.montenegro@rautakitecnologia.com.br" },       
        };

        if (description.IsDeprecated)
        {
            info.Description += " [This API version has been deprecated]";
        }

        return info;
    }
}
