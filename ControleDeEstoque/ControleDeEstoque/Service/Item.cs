using System;

public class Item
{
    public string NumeroLote { get; set; }
    public DateTime DataFabricacao { get; set; }
    public int QuantidadeEmEstoque { get; set; }
    public DateTime DataVencimento { get; set; }
    public decimal Preco { get; set; }

    public Item(string numeroLote, DateTime dataFabricacao, int quantidadeEmEstoque, DateTime dataVencimento, decimal preco)
    {
        NumeroLote = numeroLote;
        DataFabricacao = dataFabricacao;
        QuantidadeEmEstoque = quantidadeEmEstoque;
        DataVencimento = dataVencimento;
        Preco = preco;
    }
}
