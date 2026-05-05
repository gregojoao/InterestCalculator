namespace InterestCalculator.API.Responses;

public class RespostaRequisicao
{
    public bool Sucesso { get; set; }
    public string Mensagem { get; set; } = string.Empty;
    public decimal? Resultado { get; set; }

    public RespostaRequisicao() { }

    public RespostaRequisicao(bool sucesso, string mensagem, decimal? resultado)
    {
        Sucesso = sucesso;
        Mensagem = mensagem;
        Resultado = resultado;
    }
}