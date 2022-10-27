using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ConsultasProduto
{
    public static bool InserirProduto(string nome, string descricao, string fabricante, int quantidade)
    {
        var conexao = new MySqlConnection(ConexaoBD.Connection.ConnectionString);
        bool foiInserido = false;

        try
        {
            conexao.Open();
            var comando = conexao.CreateCommand();
            comando.CommandText = @"
                INSERT INTO Produto (nome, descricao, qtd, fabricante) 
                VALUES (@nome, @descricao, @qtd, @fabricante)";
            comando.Parameters.AddWithValue("@nome", nome);
            comando.Parameters.AddWithValue("@descricao", descricao);
            comando.Parameters.AddWithValue("@fabricante", fabricante);
            comando.Parameters.AddWithValue("@qtd", quantidade);
            var leitura = comando.ExecuteReader();
            foiInserido = true;
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            if(conexao.State == System.Data.ConnectionState.Open)
            {
                conexao.Close();
            }
        }
        return foiInserido;
    }

    public static bool ExcluirProduto(int id)
    {
        var conexao = new MySqlConnection(ConexaoBD.Connection.ConnectionString);
        bool foiExcluido = false;

        try
        {
            conexao.Open();
            var comando = conexao.CreateCommand();
            comando.CommandText = @"
                DELETE FROM Produto WHERE id =  @id";
            comando.Parameters.AddWithValue("@id", id);
            var leitura = comando.ExecuteReader();
            foiExcluido = true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            if (conexao.State == System.Data.ConnectionState.Open)
            {
                conexao.Close();
            }
        }
        return foiExcluido;
    }

    public static bool AlterarProduto(int id, string nome, string descricao, string fabricante, int quantidade)
    {
        var conexao = new MySqlConnection(ConexaoBD.Connection.ConnectionString);
        bool foiAtualizado = false;

        try
        {
            conexao.Open();
            var comando = conexao.CreateCommand();
            comando.CommandText = @"
                UPDATE Produto 
                SET nome = @nome, descricao = @descricao, qtd = @quantidade, fabricante = @fabricante
                WHERE id = @id" ;
            comando.Parameters.AddWithValue("@id", id);
            comando.Parameters.AddWithValue("@nome", nome);
            comando.Parameters.AddWithValue("@descricao", descricao);
            comando.Parameters.AddWithValue("@fabricante", fabricante);
            comando.Parameters.AddWithValue("@quantidade", quantidade);
            var leitura = comando.ExecuteReader(); 
            foiAtualizado = true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            if (conexao.State == System.Data.ConnectionState.Open)
            {
                conexao.Close();
            }
        }
        return foiAtualizado;
    }

    public static List<Produto> ObterTodosProdutos()
    {
        var conexao = new MySqlConnection(ConexaoBD.Connection.ConnectionString);
        List<Produto> listaDeProdutos = new List<Produto>();

        try
        {
            conexao.Open();
            var comando = conexao.CreateCommand();
            comando.CommandText = @"
                SELECT * FROM Produto;";
            var leitura = comando.ExecuteReader();
            while (leitura.Read())
            {
                Produto produto = new Produto();
                produto.id = leitura.GetInt32("id");
                produto.nome = leitura.GetString("nome");
                produto.descricao = leitura.GetString("descricao");
                produto.quantidade = leitura.GetInt32("qtd");
                produto.fabricante = leitura.GetString("fabricante");

                listaDeProdutos.Add(produto);

            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            if (conexao.State == System.Data.ConnectionState.Open)
            {
                conexao.Close();
            }
        }
        return listaDeProdutos;
    }
}
