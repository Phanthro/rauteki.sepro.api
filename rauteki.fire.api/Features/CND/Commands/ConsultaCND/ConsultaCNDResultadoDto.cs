using Newtonsoft.Json;

namespace Rauteki.Fire.Api.Features.CND.Commands.ConsultaCND;

public class ConsultaCNDResultadoDto
{
    public int Status { get; set; }

    public string? Messagem { get; set; }

    public Certidao Certidao { get; set; } = new();
}

public class Certidao
{
    public string? TipoContribuinte { get; set; }

    public string? ContribuinteCertidao { get; set; }

    public string? TipoCertidao { get; set; }

    public string? CodigoControle { get; set; }

    public DateTime DataEmissao { get; set; }

    public string? DataValidade { get; set; }

    public string? DocumentoPdf { get; set; }
}
