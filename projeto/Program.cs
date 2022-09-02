using System.Globalization;

namespace projeto;

public class Program
{
    public static void Main()
    {
        
        Console.WriteLine("Programa de gerenciamento de estoque\nDigite o nome da sua loja:");
        var nomeLoja = Console.ReadLine();
        Console.WriteLine("Digite o tamanho do estoque");
        var estoque = int.Parse(Console.ReadLine());

        var loja = new Loja(nomeLoja, estoque);
        Console.WriteLine("Digite o nome do produto, depois as unidades e depois o valor");
        var nomeProduto = Console.ReadLine();
        var unidades = Console.ReadLine();
        var valor = Console.ReadLine();

        loja.AdicionarProduto(nomeProduto, int.Parse(unidades), double.Parse(valor, new CultureInfo("en-us")));
        loja.ListarProdutos();
    }
}