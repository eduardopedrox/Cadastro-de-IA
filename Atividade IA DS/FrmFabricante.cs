using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atividade_IA_DS
{
    public partial class FrmFabricante : Form
    {
        public FrmFabricante()
        {
            InitializeComponent();
        }

        private void Fabricante_Load(object sender, EventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            SalvarFabricante();
        }

        private void SalvarFabricante()
        {
            // Cria uma nova instância da classe Fabricante
            Fabricante novoFabricante = new Fabricante
            {
                Nome = txtNomeFabricante.Text,
                Proprietario = txtProprietario.Text
            };

            // Verifica se os campos estão preenchidos
            if (string.IsNullOrWhiteSpace(novoFabricante.Nome) || string.IsNullOrWhiteSpace(novoFabricante.Proprietario))
            {
                MessageBox.Show("Por favor, preencha todos os campos.");
                return;
            }

            // Salva o fabricante
            try
            {
                novoFabricante.Salvar(novoFabricante);
                MessageBox.Show("Fabricante cadastrado com sucesso!");

                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao cadastrar fabricante: {ex.Message}");
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void LimparCampos()
        {
            Fabricante novoFabricante = new Fabricante
            {
                ID = 0,
                Nome = "",
                Proprietario = ""
            };

            cd_FabricantesTextBox.Clear();
            txtNomeFabricante.Clear();
            txtProprietario.Clear();
            txtNomeFabricante.Focus();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            FrmCategoria fc = new FrmCategoria();
            fc.ShowDialog();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Form1 fi = new Form1();
            fi.ShowDialog();
        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }
    }
}
