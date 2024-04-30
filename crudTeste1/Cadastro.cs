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
    public partial class Cadastro : Form
    {
        MySqlConnection mConn = new MySqlConnection(
           "Persist Security Info = false;" +
           "server = localhost;" +
           "database = login;" +
           "uid = root;" +
           "pwd = ");

        public Cadastro()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                mConn.Open();

                if(mConn.State == ConnectionState.Open)
                {
                    MySqlCommand comandosql = new MySqlCommand();

                    comandosql.CommandText = "INSERT INTO usuarios(" +
                        "nomeUsuarios," +
                        "foneUsuarios) VALUES('" +
                        txtNome.Text + "', '" +
                        txtFone.Text + "')";

                    comandosql.Connection = mConn;

                    comandosql.ExecuteNonQuery();


                    MessageBox.Show("Dados salvos com sucesso", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    mConn.Close();

                    this.Close();
                }

            }catch(Exception erro)
            {
                MessageBox.Show("Erro ao conectar o BD", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
