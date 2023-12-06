public class Retorno
{
    public Retorno()
    {
        
    }

    public Retorno(object? dados)
    {
        Dados = dados;
        Status = 200;
    }
    public Retorno(object? dados, int status)
    {
        Dados = dados;
        Status = status;
    }

    public int Status { get; set; }
    public object? Dados { get; set; }
}