using Banco;
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

        Transferencia tr = new Transferencia(dadosLogin);

        private void dgv_Clientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgv_Clientes.Rows[e.RowIndex];
                Transferencia.txtIdOutraConta.Text = row.Cells[0].Value.ToString();
                Transferencia.lblPessoaDeDestino.Text = row.Cells[1].Value.ToString();
            }
        }
    }
}
