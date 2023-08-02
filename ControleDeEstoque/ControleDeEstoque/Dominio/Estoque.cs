using System;
using System.Collections.Generic;

public class Estoque
{
    private List<Item> itens;

    public Estoque()
    {
        itens = new List<Item>();
    }

    public void AdicionarItem(Item item)
    {
        itens.Add(item);
    }

    public void RemoverItem(Item item)
    {
        itens.Remove(item);
    }

    public Item BuscarItemPorNumeroLote(string numeroLote)
    {
        return itens.Find(item => item.NumeroLote == numeroLote);
    }
}
