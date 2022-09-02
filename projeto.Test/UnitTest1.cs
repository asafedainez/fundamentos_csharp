using System;
using System.Globalization;
using System.IO;
using System.Linq;
using Xunit;
using FluentAssertions;

namespace projeto.Test;

public class TestarLoja
{
    [Theory(DisplayName = "Testa se posso criar uma loja")]
    [InlineData("Xablau", 20)]
    [InlineData("Loja do Zé", 50)]
    public void TestLoja(string nomeLoja, int quantidade)
    {
        var instancia = new Loja(nomeLoja, quantidade);
        instancia.Nome.Should().Be(nomeLoja);
        instancia.Estoque.Length.Should().Be(quantidade);
    }
    
    [Theory(DisplayName = "Testa se posso adicionar um produto no estoque da loja")]
    [InlineData("Produto1", 20, 50)]
    [InlineData("Produto2", 10, 2.99)]
    [InlineData("Produto3", 1, 10500.99)]
    public void TestAddProduto(string nomeProduto, int unidades, double valor)
    {
        var instancia = new Loja("", 1);
        var result = instancia.AdicionarProduto(nomeProduto, unidades, valor);

        result.Nome.Should().Be(nomeProduto);
        result.Unidades.Should().Be(unidades);
        result.Valor.Should().Be(valor);
    }
    
    [Theory(DisplayName = "Testa se falha adicionar um produto no estoque da loja")]
    [InlineData("Produto1", 20, 50)]
    [InlineData("Produto2", 10, 2.99)]
    [InlineData("Produto3", 1, 10500.99)]
    public void TestAddFailProduto(string nomeProduto, int unidades, double valor)
    {
        var instancia = new Loja("", 1);
        instancia.AdicionarProduto("", 1, 1);

        var act = () => instancia.AdicionarProduto(nomeProduto, unidades, valor);

        act.Should().Throw<IndexOutOfRangeException>()
            .WithMessage("O estoque já está cheio");
    }
    
    [Theory(DisplayName = "Testa se listagem de produtos no estoque da loja")]
    [InlineData("Produto1", 20, 50)]
    [InlineData("Produto2", 10, 2.99)]
    [InlineData("Produto3", 1, 10500.99)]
    public void TestListarProdutos(string nomeProduto, int unidades, double valor)
    {
        var writer = new StringWriter();
        var consoleDefault = Console.Out;
        
        Console.SetOut(writer);
        
        var instancia = new Loja("", 1);
        instancia.AdicionarProduto(nomeProduto, unidades, valor);
        instancia.ListarProdutos();

        var result = writer.ToString().Trim().Split(Environment.NewLine);
        result[0].Should().Contain(nomeProduto);
        result[1].Should().Contain(unidades.ToString());
        result[2].Should().Contain(valor.ToString("N2", new CultureInfo("en-us")));

        Console.SetOut(consoleDefault);
    }
    
    [Fact(DisplayName = "Testa se falha ao listar os produtos no estoque da loja")]
    public void TestListarFailProduto()
    {
        var instancia = new Loja("", 1);
        
        var act = () => instancia.ListarProdutos();

        act.Should().Throw<NullReferenceException>()
            .WithMessage("O estoque está vazio");
    }
    
    [Theory(DisplayName = "Testa se executa o programa")]
    [InlineData(new object[] {new string[] {"Loja1", "10", "Produto1", "10", "10.99"}})]
    public void TestPrograma(string[] entrada)
    {
        var reader = new StringReader(string.Join(Environment.NewLine, entrada));
        var writer = new StringWriter();
        var consoleOutDefault = Console.Out;
        var consoleInDefault = Console.In;
        
        Console.SetOut(writer);
        Console.SetIn(reader);
        
        var act = () => Program.Main();
        
        Console.SetOut(consoleOutDefault);
        Console.SetIn(consoleInDefault);
        
        
        
    }
}