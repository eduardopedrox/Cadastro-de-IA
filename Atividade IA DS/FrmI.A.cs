using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atividade_IA_DS
{
    public partial class Form1 : Form
    {
        private SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=E:\\2 MDS\\ATIVIDADE DE DS\\ATIVIDADE DE DS\\Aluguel e manutenção de aparelhora eletronicos\\banco de dados.mdf;Integrated Security=True;Connect Timeout=30");

        public string caminhoFoto = "";
        private IAs ias = new IAs();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BtnCarregarFoto_Click(object sender, EventArgs e)
        {
            CarregarFoto();
        }

        private void CarregarFoto()
        {
            var openFile = new OpenFileDialog();
            openFile.Filter = "Arquivos de imagens jpg e png|*.jpg; *.png";
            openFile.Multiselect = false;

            if (openFile.ShowDialog() == DialogResult.OK)
                caminhoFoto = openFile. FileName;

            if (caminhoFoto != "")
                pictureBox1.Load(caminhoFoto);
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            SalvarProduto();
        }

        private void SalvarProduto()
        {
            ias.Nome = txtNome.Text;
            ias.Ano = txtAno.Text;

            if (int.TryParse(txtFabricante.Text, out int fabricanteId))
            {
                using (var con = new SqlConnection(Program.conn))
                {
                    con.Open();
                    var checkSql = "SELECT COUNT(*) FROM tb_fabricante WHERE Id = @fabricanteId";
                    using (var checkCmd = new SqlCommand(checkSql, con))
                    {
                        checkCmd.Parameters.AddWithValue("@fabricanteId", fabricanteId);
                        int count = (int)checkCmd.ExecuteScalar();

                        if (count > 0)
                        {
                            ias.FabricanteId = fabricanteId; 
                            ias.CaminhoFoto = caminhoFoto;

                            // Salva a IA
                            ias.Salvar(ias);

                            MessageBox.Show("Funcionou!");
                        }
                        else
                        {
                            MessageBox.Show("O ID do fabricante informado não existe. Por favor, insira um ID válido.");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, insira um ID de fabricante válido.");
            }
        }

        private void BtnLimpar_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        private void Limpar()
        {
            ias.ID = 0;
            ias.Nome = "";
            ias.Ano = "";
            ias.FabricanteId = 0; // Limpa o ID do fabricante, assumindo que você quer resetar para um valor padrão
            ias.Foto = null;

            cd_IAsTextBox.Clear();
            txtNome.Clear();
            txtAno.Clear();
            txtFabricante.Clear();
            pictureBox1.Image = null;

            cd_IAsTextBox.Focus();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnDeletar_Click(object sender, EventArgs e)
        {
            DeletarIA();
        }

        private void DeletarIA()
        {
            int id;
            if (int.TryParse(cd_IAsTextBox.Text, out id)) // Supondo que cd_IAsTextBox é onde o usuário digita o ID
            {
                var sql = "DELETE FROM tb_IA WHERE id = @id";

                using (var con = new SqlConnection(Program.conn))
                {
                    con.Open();
                    using (var cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("IA deletada com sucesso.");
                            Limpar(); // Limpa os campos após a exclusão
                        }
                        else
                        {
                            MessageBox.Show("IA não encontrada ou já foi deletada.");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, insira um ID válido.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PesquisarIA();
        }

        private void PesquisarIA()
        {
            int id;
            if (int.TryParse(cd_IAsTextBox.Text, out id)) // Supondo que cd_IAsTextBox é onde o usuário digita o ID
            {
                var sql = @"
            SELECT i.nome, i.ano, f.nome AS fabricante, i.logo 
            FROM tb_IA i 
            JOIN tb_fabricante f ON i.fabricante_id = f.Id 
            WHERE i.id = @id";

                using (var con = new SqlConnection(Program.conn))
                {
                    con.Open();
                    using (var cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Preencher os campos do formulário
                                txtNome.Text = reader["nome"].ToString();
                                txtAno.Text = reader["ano"].ToString();
                                txtFabricante.Text = reader["fabricante"].ToString(); // Nome do fabricante

                                byte[] logo = reader["logo"] as byte[];

                                // Se houver uma imagem no banco de dados
                                if (logo != null)
                                {
                                    using (var ms = new MemoryStream(logo))
                                    {
                                        pictureBox1.Image = Image.FromStream(ms);
                                    }
                                }
                                else
                                {
                                    pictureBox1.Image = null; // Se não houver imagem
                                }
                            }
                            else
                            {
                                MessageBox.Show("IA não encontrada.");
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, insira um ID válido.");
            }
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            FrmCategoria fc = new FrmCategoria();
            fc.ShowDialog();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            FrmFabricante ff = new FrmFabricante();
            ff.ShowDialog();
        }
    }
}
