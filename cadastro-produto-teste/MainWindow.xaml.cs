using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace cadastro_produto_teste
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //DataBase Memória
        List<Produto> listaDeProdutos = new List<Produto>();   
        public MainWindow()
        {
            InitializeComponent();
            AtualizaDataGrid();
        }

        private void NovoProduto(object sender, RoutedEventArgs e)
        {
            if(verificaCamos() == true)
            {
                AdicionaProduto();
            }
        }
         
        private void AtualizarProduto(object sender, RoutedEventArgs e)
        {
            if (txtId.Text != "")
            {
                int id = int.Parse(txtId.Text);
                MessageBoxResult result = MessageBox.Show(
                    $"Deseja alterar produto id: {id}?",
                    "Atualizar Produto",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    bool foiAtualizado = cProduto.AlterarProduto(
                        id,
                        txtNome.Text,
                        txtDescricao.Text,
                        txtFabricante.Text,
                        int.Parse(txtQtd.Text)
                    );
                    if (foiAtualizado) {
                        AtualizaDataGrid();
                        MessageBoxResult information = MessageBox.Show(
                        "Produto atualizado!",
                        "Atenção",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);
                        LimpaCampos();
                    }
                }
            };
        }

        private void ExcluirProduto(object sender, RoutedEventArgs e)
        {
            if(txtId.Text != "")
            {
                int id = int.Parse(txtId.Text);
                MessageBoxResult result = MessageBox.Show(
                    $"Deseja excluir o produto id: {id}?",
                    "Excluir Produto",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);
                if(result == MessageBoxResult.Yes)
                {
                    bool foiExcluido = cProduto.ExcluirProduto(id);
                    if (foiExcluido)
                    {
                        AtualizaDataGrid();
                        MessageBoxResult information = MessageBox.Show(
                        "Produto excluido!",
                        "Atenção",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);
                        LimpaCampos();
                    }
                }
            };
        }

        private void LimparCampos(object sender, RoutedEventArgs e)
        {
            LimpaCampos();
        }

        private void PegarItemNoGrid(object sender, MouseButtonEventArgs e)
        {
            Produto produto = (Produto)dgvProdutos.SelectedItem;
            txtId.Text = produto.id.ToString();
            txtNome.Text = produto.nome;
            txtFabricante.Text = produto.fabricante;
            txtDescricao.Text = produto.descricao;
            txtQtd.Text = produto.quantidade.ToString();
        }

        private void Sair(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private bool verificaCamos()
        {
            if (txtNome.Text != "" && txtDescricao.Text != "" && txtFabricante.Text != "" && txtQtd.Text != "" )
            {
                if(txtId.Text == "")
                {
                    return true;
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show(
                    "Limpo o campo Id para inserir!",
                    "Atenção",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                    return false;
                }
                

            }
            else
            {
                return false;
                MessageBoxResult result = MessageBox.Show(
                    "Preencha todos os campos!",
                    "Atenção",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
        }
        private void AdicionaProduto()
        {
            bool foiInserido = cProduto.InserirProduto(
                txtNome.Text,
                txtDescricao.Text,
                txtFabricante.Text,
                int.Parse(txtQtd.Text)
            );
            if (foiInserido)
            {
                AtualizaDataGrid();
                MessageBoxResult result = MessageBox.Show(
                    "Produto cadastrado!",
                    "Ok",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
                LimpaCampos();
            }
            else
            {

            }

        }
        private void AtualizaDataGrid()
        {
            listaDeProdutos.Clear();
            listaDeProdutos = cProduto.ObterTodosProdutos();
            dgvProdutos.ItemsSource = listaDeProdutos;
            dgvProdutos.Items.Refresh();
        }
        private void LimpaCampos()
        {
            txtDescricao.Text = "";
            txtFabricante.Text = "";
            txtId.Text = "";
            txtNome.Text = "";
            txtQtd.Text = "";
        }

    }
}
