using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atividade_IA_DS
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        /// 

        public static readonly string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Nova pasta\Atividade IA DS\Atividade IA DS\Banco de Dados.mdf;
            Integrated Security=True;Connect Timeout=30";
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
