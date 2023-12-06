namespace Rauteki.Sepro.Api.Features.Login.Commands.LogarPorEmailESenha;

public class UsuarioPorEmailDto
{
    public int UsuarioId { get; set; }
    public string Email { get; set; } = "";
    public string Senha { get; set; } = "";
    public string Nome { get; set; } = "";
    public string Token { get; set; } = "";
    public DateTime ValidTo { get; set; }
    public IEnumerable<int> Permissoes { get; set; } = new List<int>();
    
}