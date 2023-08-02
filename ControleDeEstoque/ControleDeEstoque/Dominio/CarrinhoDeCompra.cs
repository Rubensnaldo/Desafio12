using System;
using System.Collections.Generic;

public class CarrinhoDeCompra
{
    private Dictionary<Item, int> itensNoCarrinho;

    public CarrinhoDeCompra()
    {
        itensNoCarrinho = new Dictionary<Item, int>();
    }

    public void AdicionarItem(Item item, int quantidade)
    {
        if (itensNoCarrinho.ContainsKey(item))
            itensNoCarrinho[item] += quantidade;
        else
            itensNoCarrinho[item] = quantidade;
    }

    public decimal CalcularValorTotal()
    {
        decimal valorTotal = 0;
        foreach (var item in itensNoCarrinho)
        {
            valorTotal += item.Key.Preco * item.Value;
        }
        return valorTotal;
    }

    public Dictionary<Item, int> ObterItensNoCarrinho()
    {
        return itensNoCarrinho;
    }
}
