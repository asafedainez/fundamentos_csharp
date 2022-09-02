namespace projeto;

public class Produto
{
    private readonly string nome;
    private int unidades;
    private double valor;

    public Produto(string nome, int unidades, double valor)
    {
        this.nome = nome;
        this.unidades = unidades;
        this.valor = valor;
    }

    public int Unidades
    {
        get => unidades;
        set => unidades = value;
    }

    public double Valor
    {
        get => valor;
        set => valor = value;
    }

    public string Nome => nome;
}