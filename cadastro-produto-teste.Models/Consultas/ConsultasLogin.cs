using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ConsultasLogin
{
    public static bool VerificarUsuarioExistente(string email)
    {
        var conexao = new MySqlConnection(ConexaoBD.Connection.ConnectionString);
        bool usuarioExiste = false;

        try
        {
            conexao.Open();
            var comando = conexao.CreateCommand();
            comando.CommandText = @"
                SELECT * FROM Usuario
                WHERE email = @email";
            comando.Parameters.AddWithValue("@email", email);
            var leitura = comando.ExecuteReader();
            while (leitura.Read())
            {
                usuarioExiste = true;
                break;
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
        return usuarioExiste;
    }
    public static bool CadastrarUsuario(string email, string senha)
    {
        var conexao = new MySqlConnection(ConexaoBD.Connection.ConnectionString);
        bool foiInserido = false;
        string senhaCriptografada = Criptografia.CriptografarMD5Senha(senha);

        try
        {
            conexao.Open();
            var comando = conexao.CreateCommand();
            comando.CommandText = @"
                INSERT INTO Usuario (email, senha) 
                VALUES (@email, @senha)";
            comando.Parameters.AddWithValue("@email", email);
            comando.Parameters.AddWithValue("@senha", senhaCriptografada);
            var leitura = comando.ExecuteReader();
            foiInserido = true;
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
        return foiInserido;
    }
    public static bool ExcluirUsuario(int id)
    {
        var conexao = new MySqlConnection(ConexaoBD.Connection.ConnectionString);
        bool foiExcluido = false;

        try
        {
            conexao.Open();
            var comando = conexao.CreateCommand();
            comando.CommandText = @"
                DELETE FROM Usuario WHERE id =  @id";
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
    public static Usuario ObterUsuarioPeloLoginSenha(string email, string senha)
    {
        var conexao = new MySqlConnection(ConexaoBD.Connection.ConnectionString);
        Usuario usuario = null;
        string senhaCriptografada = Criptografia.CriptografarMD5Senha(senha);

        try
        {
            conexao.Open();
            var comando = conexao.CreateCommand();
            comando.CommandText = @"
                SELECT * FROM Usuario
                WHERE email = @email and senha = @senha";
            comando.Parameters.AddWithValue("@email", email);
            comando.Parameters.AddWithValue("@senha", senhaCriptografada);
            var leitura = comando.ExecuteReader();
            while (leitura.Read())
            {
                usuario = new Usuario();
                usuario.id = leitura.GetInt32("id");
                usuario.email = leitura.GetString("email");
                usuario.senha = leitura.GetString("senha");
                break;
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

        return usuario;
    }

}
