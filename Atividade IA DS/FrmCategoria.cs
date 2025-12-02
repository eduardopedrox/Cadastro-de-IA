using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atividade_IA_DS
{
    public partial class FrmCategoria : Form
    {
        public FrmCategoria()
        {
            InitializeComponent();
        }

        private void Categoria_Load(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.ShowDialog();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            FrmFabricante ff = new FrmFabricante();
            ff.ShowDialog();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            SalvarCategoria();
        }

        private void SalvarCategoria()
        {
            // Cria uma nova instância da classe Categoria
            cate novaCategoria = new cate
            {
                Nome = txtNomeCategoria.Text,
                Profissao = txtProfissao.Text
            };

            // Verifica se os campos estão preenchidos
            if (string.IsNullOrWhiteSpace(novaCategoria.Nome) || string.IsNullOrWhiteSpace(novaCategoria.Profissao))
            {
                MessageBox.Show("Por favor, preencha todos os campos.");
                return;
            }

            // Chama o método Salvar da classe Categoria
            novaCategoria.Salvar(novaCategoria);

            MessageBox.Show("Categoria cadastrada com sucesso!");

            LimparCampos();
        }

        private void LimparCampos()
        {
            cate novaCategoria = new cate
            {
                ID = 0,
                Nome = "",
                Profissao = ""
            };

            cd_CategoriaTextBox.Clear();
            txtNomeCategoria.Clear();
            txtProfissao.Clear();
            txtNomeCategoria.Focus();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }
    }
}
