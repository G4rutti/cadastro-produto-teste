using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class cProduto
{
    public static bool InserirProduto(string nome, string descricao, string fabricante, int quantidade)
    { 
        return ConsultasProduto.InserirProduto(nome, descricao, fabricante, quantidade);
    }

    public static bool ExcluirProduto(int id)
    {
        return ConsultasProduto.ExcluirProduto(id);
    }

    public static bool AlterarProduto(int id, string nome, string descricao, string fabricante, int quantidade)
    {
        return ConsultasProduto.AlterarProduto(id, nome, descricao, fabricante, quantidade);
    }

    public static List<Produto> ObterTodosProdutos()
    {
        return ConsultasProduto.ObterTodosProdutos();
    }
}
