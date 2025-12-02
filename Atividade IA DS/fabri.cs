using System;
using System.Data.SqlClient;

namespace Atividade_IA_DS
{
    class Fabricante
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Proprietario { get; set; }

        public void Salvar(Fabricante fabricante)
        {
            var sql = "INSERT INTO tb_fabricante (nome, proprietario) VALUES (@nome, @proprietario)";

            using (var con = new SqlConnection(Program.conn))
            {
                con.Open();
                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@nome", fabricante.Nome);
                    cmd.Parameters.AddWithValue("@proprietario", fabricante.Proprietario);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}