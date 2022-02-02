using Banco;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace ExemploBanco
{
    public partial class Extrato : Form
    {

        #region Construtor

        public Extrato(DadosLogin dadosLogin)
        {
            InitializeComponent();

            this.dadosLogin = dadosLogin;
        }

        #endregion

        #region Atributos

        private DadosLogin dadosLogin = null;
        private Operacoes op = new Operacoes();

        public bool HasError { get; set; } = false;
        public string MsgError { get; set; } = string.Empty;

        #endregion

        #region Eventos

        private void Extrato_Load(object sender, EventArgs e)
        {
            DataTable result = op.ListarExtrato(dadosLogin.id_login);

            dgv_ExtratoLegal.DataSource = result;
        }

        #endregion

        
    }
}
