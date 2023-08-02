using System;

public class Program
{
    public static void Main(string[] args)
    {
        Estoque estoque = new Estoque();

        // Adicionar alguns itens ao estoque para testar
        estoque.AdicionarItem(new Item("L001", new DateTime(2023, 1, 1), 10, new DateTime(2023, 12, 31), 10.0m));
        estoque.AdicionarItem(new Item("L002", new DateTime(2023, 2, 1), 5, new DateTime(2024, 2, 1), 20.0m));
        estoque.AdicionarItem(new Item("L003", new DateTime(2023, 3, 1), 15, new DateTime(2024, 3, 1), 5.0m));

        CarrinhoDeCompra carrinho = new CarrinhoDeCompra();

        bool sair = false;
        while (!sair)
        {
            Console.WriteLine("========= MENU =========");
            Console.WriteLine("1. Adicionar item ao carrinho");
            Console.WriteLine("2. Ver itens no carrinho");
            Console.WriteLine("3. Calcular valor total do carrinho");
            Console.WriteLine("4. Finalizar venda");
            Console.WriteLine("5. Sair");
            Console.WriteLine("=========================");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Console.Write("Digite o número do lote do item: ");
                    string numeroLote = Console.ReadLine();
                    Item item = estoque.BuscarItemPorNumeroLote(numeroLote);
                    if (item == null)
                    {
                        Console.WriteLine("Item não encontrado no estoque.");
                    }
                    else
                    {
                        Console.Write("Digite a quantidade: ");
                        int quantidade = int.Parse(Console.ReadLine());
                        carrinho.AdicionarItem(item, quantidade);
                        Console.WriteLine("Item adicionado ao carrinho com sucesso!");
                    }
                    break;

                case "2":
                    Console.WriteLine("Itens no carrinho:");
                    foreach (var itemCarrinho in carrinho.ObterItensNoCarrinho())
                    {
                        Console.WriteLine($"Número Lote: {itemCarrinho.Key.NumeroLote}, Quantidade: {itemCarrinho.Value}, Preço: R${itemCarrinho.Key.Preco}");
                    }
                    break;

                case "3":
                    decimal valorTotalCarrinho = carrinho.CalcularValorTotal();
                    Console.WriteLine("Valor total do carrinho: R$" + valorTotalCarrinho);
                    break;

                case "4":
                    Console.WriteLine("Formas de pagamento: dinheiro, cartao credito, cartao debito");
                    Console.Write("Digite a forma de pagamento: ");
                    string formaPagamento = Console.ReadLine().ToLower();
                    Venda venda = new Venda(carrinho);
                    venda.FinalizarVenda(formaPagamento);
                    carrinho = new CarrinhoDeCompra(); // Limpar carrinho após a venda
                    break;

                case "5":
                    sair = true;
                    break;

                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }

            Console.WriteLine(); // Adicionar uma linha em branco para melhorar a visualização do menu
        }

        Console.WriteLine("Obrigado por usar o sistema de controle de estoque e vendas!");
    }
}
