using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace login_para_teste
{
    /// <summary>
    /// Lógica interna para FrmCadastroUsuario.xaml
    /// </summary>
    public partial class FrmCadastroUsuario : Window
    {
        public FrmCadastroUsuario()
        {
            InitializeComponent();
        }

        private void VoltarParaTelaLogin(object sender, MouseButtonEventArgs e)
        {
            FrmLoginUsuario frmLoginUsuario = new FrmLoginUsuario();
            frmLoginUsuario.Show();
            Close();
        }

        private void AbrirTelaLogin()
        {
            FrmLoginUsuario frmLoginUsuario = new FrmLoginUsuario();
            frmLoginUsuario.Show();
            Close();
        }
        private void CadastrarUsuario(object sender, RoutedEventArgs e)
        {
            if (VerificarCampos() == true)
            {
                string email = txtEmail.Text;
                Regex rg = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");

                if (rg.IsMatch(email))
                {
                    string senha = txtSenha.Password;
                    bool usuarioExiste = cUsuario.VerificarUsuarioExistente(email);
                    bool validaCadastro = cUsuario.CadastrarUsuario(email, senha);
                    if (usuarioExiste == false)
                    {
                        if (validaCadastro)
                        {
                            MessageBoxResult result = MessageBox.Show(
                            "Seu cadastro foi concluido com sucesso!",
                            "Sucesso!",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information
                            );
                            AbrirTelaLogin();
                        }
                        else
                        {
                            MessageBoxResult result = MessageBox.Show(
                            "Houve algum erro! Tente novamente mais tarde.",
                            "Erro",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error
                            );
                        }
                    }
                    else
                    {
                        MessageBoxResult result = MessageBox.Show(
                        "Email já existe!",
                        "Atenção",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning
                    );
                    }
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show(
                       "Escreva um Email Válido",
                       "Atenção",
                       MessageBoxButton.OK,
                       MessageBoxImage.Warning
                       );
                }


            }
        }

        private bool VerificarCampos()
        {
            if (txtEmail.Text != "" && txtSenha.Password != "" && txtConfirmaSenha.Password != "")
            {
                if (txtSenha.Password != txtConfirmaSenha.Password)
                {
                    MessageBoxResult result = MessageBox.Show(
                    "As senhas nao são iguais!",
                    "Atenção",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning
                    );
                    return false;


                }
                else
                {
                    return true;
                }
            }
            else
            {
                MessageBoxResult result = MessageBox.Show(
                    "Preencha todos os campos!",
                    "Atenção",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning
                    );
                return false;


            }
        }
    }
}
