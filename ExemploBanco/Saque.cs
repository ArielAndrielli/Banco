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
            double saldoSaque = op.Extrato(dadosLogin.id_login); //verifica se aqui volta um double, se não voltar, faz o convert double

            lblSaldo.Text = saldoSaque.ToString("N2"); //isso vai formatar pra ficar com 2 casas decimais e com pontuação
        }

        private void Saque_Load(object sender, EventArgs e)
        {
            AtualizarSaldo();
        }

        private void btnSacar_Click(object sender, EventArgs e)
        {
            op.id_conta = dadosLogin.id_login;

            if (txtSaque.Text == string.Empty)
            {
                MessageBox.Show("Campo Obrigatório!");
                return;
            }

            if (System.Text.RegularExpressions.Regex.IsMatch(txtSaque.Text, "[^0-9]"))
            {
                MessageBox.Show("Valor Inválido!");
                txtSaque.Text = txtSaque.Text.Remove(txtSaque.Text.Length - 1);
                txtSaque.Text = string.Empty;
                return;
            }

            op.valor = double.Parse(txtSaque.Text.Trim());

            if (op.valor < 0 || op.valor > double.Parse(lblSaldo.Text))
            {
                MessageBox.Show("Saldo Insuficiente!");
                return;
            }


            if (op.valor > 0 || op.valor <= double.Parse(txtSaque.Text))
            {
                op.S();
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
