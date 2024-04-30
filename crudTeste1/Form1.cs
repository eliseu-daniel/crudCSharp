using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace crudTeste1
{
    public partial class Inicial : Form
    {
        MySqlConnection mConn = new MySqlConnection(
            "Persist Security Info = false;" +
            "server = localhost;" +
            "database = login;" +
            "uid = root;" +
            "pwd = ");

        public Inicial()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Cadastro telaCad = new Cadastro();
            telaCad.ShowDialog();
        }

        private void Inicial_Load(object sender, EventArgs e)
        {
            btnRefresh.PerformClick();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                mConn.Open();

                if (mConn.State == ConnectionState.Open)
                {
                    dgvUsers.ColumnCount = 3;
                    dgvUsers.Columns[0].Width = 50;
                    dgvUsers.Columns[0].Name = "ID";

                    dgvUsers.Columns[1].Width = 91;
                    dgvUsers.Columns[1].Name = "Nome";

                    dgvUsers.Columns[2].Width = 91;
                    dgvUsers.Columns[2].Name = "Fone";

                    MySqlCommand comandosql = mConn.CreateCommand();

                    comandosql.CommandText = "SELECT * FROM usuarios";

                    comandosql.Connection = mConn;

                    MySqlDataReader dados = comandosql.ExecuteReader();

                    dgvUsers.Rows.Clear();

                    while (dados.Read())
                    {
                        string[] linha = new string[]
                        {
                            dados["idUsuarios"].ToString(),
                            dados["nomeUsuarios"].ToString(),
                            dados["foneUsuarios"].ToString()
                        };
                        dgvUsers.Rows.Add(linha);
                    }

                    mConn.Close();
                }
                else
                {
                    MessageBox.Show("Erro ao atualizar BD", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }


            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao conectar o BD", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
