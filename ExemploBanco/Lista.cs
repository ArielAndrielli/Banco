using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace ExemploBanco
{
    public partial class Lista : Form
    {

        #region Construtor

        public Lista()
        {
            InitializeComponent();
        }

        #endregion

        #region Atributos

        private const string connectionString = "Server=localhost;User=root;Password=sql$user;Database=dbteste;";

        public string userEscolhido { get; private set; }
        public string userEscolhido2 { get; private set; }
        public bool HasError { get; set; } = false;
        public string MsgError { get; set; } = string.Empty;

        #endregion

        #region Métodos

        public DataTable Listar(string pTudo)
        {
            HasError = false;
            MsgError = string.Empty;

            MySqlConnection connection = null;
            MySqlCommand command = null;
            MySqlDataAdapter dataAdapter = null;

            DataTable result = null;

            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();

                command = connection.CreateCommand();
                command.CommandText = "SELECT Id, Nome FROM tblogin ORDER BY Id;";

                dataAdapter = new MySqlDataAdapter(command);
                result = new DataTable();
                dataAdapter.Fill(result);
            }
            catch (Exception ex)
            {
                HasError = true;
                MsgError = ex.Message;
            }
            finally
            {
                if (connection != null)
                    connection.Dispose();

                if (command != null)
                    command.Dispose();

                if (dataAdapter != null)
                    dataAdapter.Dispose();
            }

            return result;
        }

        #endregion

        #region Eventos

        private void Lista_Load(object sender, EventArgs e)
        {
            DataTable result = Listar(string.Empty);

            dgv_Clientes.DataSource = result;

        }

        private void dgv_Clientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgv_Clientes.Rows[e.RowIndex];
                userEscolhido = row.Cells[0].Value.ToString();
                userEscolhido2 = row.Cells[1].Value.ToString();
                Hide();
            }
        }

        #endregion


    }
}
