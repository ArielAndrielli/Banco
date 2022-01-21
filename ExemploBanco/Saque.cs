using Banco;
using ExemploBanco;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExemploBanco
{
    public partial class Saque : Form
    {
        #region Construtor

        public Saque(DadosLogin dadosLogin)
        {
            InitializeComponent();

            this.dadosLogin = dadosLogin;
        }

        #endregion

        #region Atributos

        private DadosLogin dadosLogin = null;
        private Operacoes op = new Operacoes();

        #endregion

        #region Eventos

        public void AtualizarSaldo()
        {
            lblSaldo.Text = Convert.ToString(op.MostrarSaldo(dadosLogin.id_login));
        }

        private void Saque_Load(object sender, EventArgs e)
        {
            AtualizarSaldo();
        }

        private void btnSacar_Click(object sender, EventArgs e)
        {
            op.id = dadosLogin.id_login;

            if (txtSaque.Text == string.Empty)
            {
                MessageBox.Show("Campo Obrigatório!");
                return;
            }

            op.saldo = double.Parse(txtSaque.Text.Trim());

            if (op.saldo < 0 || op.saldo > double.Parse(lblSaldo.Text))
            {
                MessageBox.Show("Saldo Insuficiente!");
                return;
            }


            if (op.saldo > 0 || op.saldo <= double.Parse(txtSaque.Text))
            {
                op.Sacar();
            }


            if (op.HasError)
            {
                MessageBox.Show(op.MsgError, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            MessageBox.Show("Saque realizado com sucesso!",
                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            DialogResult dg = MessageBox.Show("Deseja realizar outro saque?", "Aviso",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
            {
                AtualizarSaldo();
                txtSaque.Text = string.Empty;
                return;
            }
            else
            {
                this.Close();
            }
        }


        #endregion


    }
}
