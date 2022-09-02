using System.Globalization;

namespace projeto;

public class Loja
{
    private readonly string nome;
    private Produto[] estoque;
    private int qntTotalProdutos;

    public Loja(string nomeLoja, int qntTotalProdutos)
    {
        this.nome = nomeLoja;
        estoque = new Produto[qntTotalProdutos];
        this.qntTotalProdutos = 0;
    }

    public string Nome => nome;

    public Produto[] Estoque
    {
        get => estoque;
    }

    public Produto AdicionarProduto(string nome, int unidades, double valor)
    {
        if (qntTotalProdutos == estoque.Length)
        {
            throw new IndexOutOfRangeException("O estoque já está cheio");
        }

        estoque[qntTotalProdutos] = new Produto(nome, unidades, valor);
        qntTotalProdutos++;
        return estoque[qntTotalProdutos - 1];
    }

    public void ListarProdutos()
    {
        if (qntTotalProdutos == 0)
        {
            throw new NullReferenceException("O estoque está vazio");
        }

        for (var i = 0; i < qntTotalProdutos; i++)
        {
            Console.WriteLine($"Nome: {estoque[i].Nome}\n" +
                              $"Unidades: {estoque[i].Unidades}\n" +
                              $"Valor: ${estoque[i].Valor.ToString("N2",new CultureInfo("en-us"))}");
            Console.WriteLine("--------------------");
        }
    }

    public Produto EditarProduto(string nome, int unidades, double valor)
    {
        if (qntTotalProdutos == 0)
        {
            throw new NullReferenceException("O estoque está vazio");
        }
        
        for (var i = 0; i < qntTotalProdutos; i++)
        {
            if (estoque[i].Nome == nome)
            {
                estoque[i] = new Produto(nome, unidades, valor);
                return estoque[i];
            }
        }

        throw new Exception("Não existe esse produto no estoque!!");
    }
}






