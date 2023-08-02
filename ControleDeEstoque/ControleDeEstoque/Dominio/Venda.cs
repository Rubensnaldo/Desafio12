using ControleDeEstoque.Dominio;
using System;

public class Venda
{
    private CarrinhoDeCompra carrinho;

    public Venda(CarrinhoDeCompra carrinho)
    {
        this.carrinho = carrinho;
    }

    public void FinalizarVenda(string formaPagamento)
    {
        decimal valorTotal = carrinho.CalcularValorTotal();
        decimal desconto = 0;

        if (valorTotal > 300 && (formaPagamento == "dinheiro" || formaPagamento == "cartao debito"))
        {
            // Sortear o desconto entre 10%, 12%, 14%, 17% ou 20%
            Random random = new Random();
            int[] possiveisDescontos = { 10, 12, 14, 17, 20 };
            int descontoPercentual = possiveisDescontos[random.Next(possiveisDescontos.Length)];
            desconto = valorTotal * (decimal)descontoPercentual / 100;
            valorTotal -= desconto;

            Console.WriteLine($"Parabéns! Você ganhou {descontoPercentual}% de desconto na sua compra.");
        }

        if (formaPagamento == "dinheiro" || formaPagamento == "cartao debito")
        {
            Console.WriteLine($"Total a pagar com desconto: R${valorTotal}");
        }
        else
        {
            Console.WriteLine($"Total a pagar: R${valorTotal}");
        }

        // Simular outras operações, como emissão da nota fiscal e remoção do estoque
        Console.WriteLine("Venda finalizada!");
    }
}
