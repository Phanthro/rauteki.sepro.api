namespace Rauteki.Fire.Api.Features.Usuario.Queries.ObterUsuario;

public class ObterUsuarioDto
{
    public int UsuarioId { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Sobrenome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public bool IsAtivo { get; set; }
    
    
}