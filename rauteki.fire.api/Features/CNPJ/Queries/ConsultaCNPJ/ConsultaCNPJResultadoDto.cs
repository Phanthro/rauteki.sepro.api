using Newtonsoft.Json;

namespace Rauteki.Fire.Api.Features.CNPJ.Queries.ConsultaCNPJ;

public class ConsultaCNPJResultadoDto
{

    [JsonProperty("ni")]
    public string? Ni { get; set; }

    [JsonProperty("tipoEstabelecimento")]
    public string? TipoEstabelecimento {get; set;}

    [JsonProperty("nomeEmpresarial")]
    public string? NomeEmpresarial { get; set; }

    [JsonProperty("nomeFantasia")]
    public string? NomeFantasia { get; set; }

    [JsonProperty("situacaoCadastral")]
    public SituacaoCadastral SituacaoCadastral { get; set; } = new();

    [JsonProperty("naturezaJuridica")]
    public NaturezaJuridica NaturezaJuridica { get; set; } = new();

    [JsonProperty("dataAbertura")]
    public string? DataAbertura { get; set; }

    [JsonProperty("cnaePrincipal")]
    public CnaePrincipal CnaePrincipal { get; set; } = new();

    [JsonProperty("cnaeSecundarias")]
    public List<CnaeSecundaria> CnaeSecundarias { get; set; } = new();

    [JsonProperty("endereco")]
    public Endereco Endereco { get; set; } = new();

    [JsonProperty("municipioJurisdicao")]
    public MunicipioJurisdicao MunicipioJurisdicao { get; set; } = new();

    [JsonProperty("telefones")]
    public List<Telefone> Telefones { get; set; } = new();

    [JsonProperty("correioEletronico")]
    public string? CorreioEletronico { get; set; }

    [JsonProperty("capitalSocial")]
    public string? CapitalSocial { get; set; }

    [JsonProperty("porte")]
    public string? Porte { get; set; }

    [JsonProperty("situacaoEspecial")]
    public string? SituacaoEspecial { get; set; }

    [JsonProperty("dataSituacaoEspecial")]
    public string? DataSituacaoEspecial { get; set; }

    [JsonProperty("informacoesAdicionais")]
    public InformacoesAdicionais InformacoesAdicionais { get; set; } = new();

    [JsonProperty("socios")]
    public List<Socio> Socios { get; set; } = new();
}

public class CnaePrincipal
{
    [JsonProperty("codigo")]
    public string? Codigo { get; set; }

    [JsonProperty("descricao")]
    public string? Descricao { get; set; }
}

public class CnaeSecundaria
{
    [JsonProperty("codigo")]
    public string? Codigo { get; set; }

    [JsonProperty("descricao")]
    public string? Descricao { get; set; }
}

public class Endereco
{
    [JsonProperty("tipoLogradouro")]
    public string? TipoLogradouro { get; set; }

    [JsonProperty("logradouro")]
    public string? Logradouro { get; set; }

    [JsonProperty("numero")]
    public string? Numero { get; set; }

    [JsonProperty("complemento")]
    public string? Complemento { get; set; }

    [JsonProperty("cep")]
    public string? Cep { get; set; }

    [JsonProperty("bairro")]
    public string? Bairro { get; set; }

    [JsonProperty("municipio")]
    public Municipio Municipio { get; set; } = new();

    [JsonProperty("uf")]
    public string? Uf { get; set; }

    [JsonProperty("pais")]
    public Pais Pais { get; set; } = new();
}

public class InformacoesAdicionais
{
    [JsonProperty("optanteSimples")]
    public string? OptanteSimples { get; set; }

    [JsonProperty("optanteMei")]
    public string? OptanteMei { get; set; }

    [JsonProperty("listaPeriodoSimples")]
    public List<ListaPeriodoSimple> ListaPeriodoSimples { get; set; } = new();
}

public class ListaPeriodoSimple
{
    [JsonProperty("dataInicio")]
    public string? DataInicio { get; set; }

    [JsonProperty("dataFim")]
    public string? DataFim { get; set; }
}

public class Municipio
{
    [JsonProperty("codigo")]
    public string? Codigo { get; set; }

    [JsonProperty("descricao")]
    public string? Descricao { get; set; }
}

public class MunicipioJurisdicao
{
    [JsonProperty("codigo")]
    public string? Codigo { get; set; }

    [JsonProperty("descricao")]
    public string? Descricao { get; set; }
}

public class NaturezaJuridica
{
    [JsonProperty("codigo")]
    public string? Codigo { get; set; }

    [JsonProperty("descricao")]
    public string? Descricao { get; set; }
}

public class Pais
{
    [JsonProperty("codigo")]
    public string? Codigo { get; set; }

    [JsonProperty("descricao")]
    public string? Descricao { get; set; }
}

public class RepresentanteLegal
{
    [JsonProperty("nome")]
    public string? Nome { get; set; }

    [JsonProperty("qualificacao")]
    public string? Qualificacao { get; set; }
}



public class SituacaoCadastral
{
    [JsonProperty("codigo")]
    public string? Codigo { get; set; }

    [JsonProperty("data")]
    public string? Data { get; set; }

    [JsonProperty("motivo")]
    public string? Motivo { get; set; }
}

public class Socio
{
    [JsonProperty("tipoSocio")]
    public string? TipoSocio { get; set; }

    [JsonProperty("nome")]
    public string? Nome { get; set; }

    [JsonProperty("qualificacao")]
    public string? Qualificacao { get; set; }

    [JsonProperty("pais")]
    public Pais Pais { get; set; } = new();

    [JsonProperty("representanteLegal")]
    public RepresentanteLegal RepresentanteLegal { get; set; } = new();
}

public class Telefone
{
    [JsonProperty("ddd")]
    public string? Ddd { get; set; }

    [JsonProperty("numero")]
    public string? Numero { get; set; }
}



