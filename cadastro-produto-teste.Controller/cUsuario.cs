using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class cUsuario
{
    public static bool VerificarUsuarioExistente(string email)
    {
        return ConsultasLogin.VerificarUsuarioExistente(email);
    }
    public static bool CadastrarUsuario(string email, string senha)
    {
        return ConsultasLogin.CadastrarUsuario(email, senha);
    }
    public static bool ExcluirUsuario(int id)
    {
        return ConsultasLogin.ExcluirUsuario(id);
    }
    public static Usuario ObterUsuarioPeloLoginSenha(string email, string senha)
    {
        return ConsultasLogin.ObterUsuarioPeloLoginSenha(email,senha);
    }
}