namespace Rauteki.Fire.Api.Features.Usuario.Commands.AlterarUsuario;

public class AlterarUsuarioDto
{
   public int UsuarioId { get; set; }
   public string Email { get; set; } = "";
   public string Nome { get; set; } = "";
   public string Senha { get; set; } = "";
   public string Telefone { get; set; } = "";

}