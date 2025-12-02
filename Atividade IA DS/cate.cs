using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade_IA_DS
{
    class cate
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Profissao { get; set; }

        // Método para salvar uma categoria no banco de dados
        public void Salvar(cate categoria)
        {
            var sql = "INSERT INTO tb_categoria (nome, profissao) VALUES (@nome, @profissao)";

            using (var con = new SqlConnection(Program.conn))
            {
                con.Open();
                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@nome", categoria.Nome);
                    cmd.Parameters.AddWithValue("@profissao", categoria.Profissao);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}