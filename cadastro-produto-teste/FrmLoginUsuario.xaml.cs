using cadastro_produto_teste;
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
    /// Lógica interna para FrmLoginUsuario.xaml
    /// </summary>
    public partial class FrmLoginUsuario : Window
    {
        public FrmLoginUsuario()
        {
            InitializeComponent();
        }

        private void AbrirTelaCadastroUsuario(object sender, MouseButtonEventArgs e)
        {
            FrmCadastroUsuario frmCadastro = new FrmCadastroUsuario();
            frmCadastro.Show();
            Close();
        }

        private void FecharAplicacao(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void AbrirTelaMenu()
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
        private void FazerLogin(object sender, RoutedEventArgs e)
        {
            if (VerificarCampos() == true)
            {
                string email = txtEmail.Text;
                Regex rg = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");
                if (rg.IsMatch(email))
                {
                    string senha = txtPassword.Password;
                    Usuario usuario = cUsuario.ObterUsuarioPeloLoginSenha(email, senha);
                    if (usuario != null)
                    {
                        AbrirTelaMenu();
                    }
                    else
                    {
                        MessageBoxResult result = MessageBox.Show(
                       "Email ou senha incorretos!",
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
            if (txtEmail.Text != "" && txtPassword.Password != "")
            {
                return true;
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
