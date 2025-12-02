using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;

namespace Atividade_IA_DS
{
    class IAs
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Ano { get; set; }
        public int FabricanteId { get; set; } // Alterado para armazenar o ID do fabricante
        public string CaminhoFoto { get; set; }
        public byte[] Foto { get; set; }

        public void Salvar(IAs ias)
        {
            byte[] foto = GetFoto(ias.CaminhoFoto);

            var sql = "INSERT INTO tb_IA (nome, ano, fabricante_id, logo) VALUES (@nome, @ano, @fabricante_id, @logo)";

            using (var con = new SqlConnection(Program.conn))
            {
                con.Open();
                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@nome", ias.Nome);
                    cmd.Parameters.AddWithValue("@ano", ias.Ano);
                    cmd.Parameters.AddWithValue("@fabricante_id", ias.FabricanteId); // Usando fabricante_id
                    cmd.Parameters.Add("@logo", System.Data.SqlDbType.Image, foto.Length).Value = foto;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        private byte[] GetFoto(string caminhoFoto)
        {
            byte[] foto;
            using (var stream = new FileStream(caminhoFoto, FileMode.Open, FileAccess.Read))
            {
                using (var reader = new BinaryReader(stream))
                {
                    foto = reader.ReadBytes((int)stream.Length);
                }
            }
            return foto;
        }
    }
}