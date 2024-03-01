namespace Rauteki.Fire.Api.Features.Usuario.Commands.CriarNovoUsuario;

public class CriarNovoUsuarioDto
{
   public string Email { get; set; } = "";
   public string Nome { get; set; } = "";
   public string Senha { get; set; } = "";
   public string Telefone { get; set; } = "";
   public int ClienteId { get; set; }

}