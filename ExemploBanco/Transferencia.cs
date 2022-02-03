using Banco;
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
    public partial class Transferencia : Form
    {

        #region Construtor
        public Transferencia(DadosLogin dadosLogin)
        {
            InitializeComponent();

            this.dadosLogin = dadosLogin;
        }

        public Transferencia()
        {
        }

        #endregion

        #region Atributos

        private DadosLogin dadosLogin = null;
        private Operacoes op = new Operacoes();

        #endregion

        #region Método

        public void AtualizarSaldo()
        {
            double saldoSaque = op.Saldo(dadosLogin.id_login); //verifica se aqui volta um double, se não voltar, faz o convert double

            lblSaldo.Text = saldoSaque.ToString("N2"); //isso vai formatar pra ficar com 2 casas decimais e com pontuação
        }

        #endregion

        #region Eventos

        private void Transferencia_Load(object sender, EventArgs e)
        {
            AtualizarSaldo();
        }

        private void btnTransferir_Click(object sender, EventArgs e)
        {

            #region Debitando

            op.id_conta = dadosLogin.id_login;
            double.TryParse(txtTransferencia.Text.Trim(), out double saldo);
            op.valor = saldo;
            op.tipo = "D";
            op.desc = "Transferência";

            if (txtIdOutraConta.Text == string.Empty && txtTransferencia.Text == string.Empty)
            {
                MessageBox.Show("Campos Obrigatórios!");
                return;
            }

            if (System.Text.RegularExpressions.Regex.IsMatch(txtTransferencia.Text, "[^0-9]"))
            {
                MessageBox.Show("Valor Inválido!");
                txtTransferencia.Text = txtTransferencia.Text.Remove(txtTransferencia.Text.Length - 1);
                txtTransferencia.Text = string.Empty;
                return;
            }

            if (op.valor < 1)
            {
                MessageBox.Show("Valor Inválido!");
                return;
            }

            if (txtIdOutraConta.Text == string.Empty)
            {
                MessageBox.Show("Destinatário não informado!");
                return;
            }

            if (txtTransferencia.Text == string.Empty)
            {
                MessageBox.Show("Você deve informar um valor para transferência!");
                return;
            }

            //op.id_dest = int.Parse(txtIdOutraConta.Text);

            if (op.valor <= double.Parse(lblSaldo.Text))
            {
                op.Incluir();
            }
            else if (Convert.ToDouble(txtTransferencia.Text) > double.Parse(lblSaldo.Text))
            {
                MessageBox.Show("Saldo Insuficiente!");
                return;
            }

            if (op.HasError)
            {
                MessageBox.Show(op.MsgError, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            #endregion

            #region Creditando

            op.id_conta = int.Parse(txtIdOutraConta.Text);
            op.valor = saldo;
            op.tipo = "C";
            op.desc = "Transferência";

            //op.id_dest = int.Parse(txtIdOutraConta.Text);

            if (op.valor <= double.Parse(lblSaldo.Text))
            {
                op.Incluir();
            }
            else if (Convert.ToDouble(txtTransferencia.Text) > double.Parse(lblSaldo.Text))
            {
                MessageBox.Show("Saldo Insuficiente!");
                return;
            }

            if (op.HasError)
            {
                MessageBox.Show(op.MsgError, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            MessageBox.Show("Transferência realizada com sucesso!",
                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            DialogResult diag = MessageBox.Show("Deseja realizar outra transferência?", "Aviso",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (diag == DialogResult.Yes)
            {
                AtualizarSaldo();
                txtIdOutraConta.Text = string.Empty;
                txtTransferencia.Text = string.Empty;
                return;
            }
            else
            {
                this.Close();
            }

            #endregion
        }

        private void txtIdOutraConta_TextChanged(object sender, EventArgs e)
        {
            //////////////////////////////////////////////////
            
            if (txtIdOutraConta.Text == string.Empty)
            {
                lblPessoaDeDestino.Text = string.Empty;
                return;
            }

            if (System.Text.RegularExpressions.Regex.IsMatch(txtIdOutraConta.Text, "[^0-9]"))
            {
                MessageBox.Show("Valor Inválido!");
                txtIdOutraConta.Text = txtIdOutraConta.Text.Remove(txtIdOutraConta.Text.Length - 1);
                txtIdOutraConta.Text = string.Empty;
                return;
            }

            int id = int.Parse(txtIdOutraConta.Text);

            if (op.HasError)
            {
                MessageBox.Show(op.MsgError, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            lblPessoaDeDestino.Text = Convert.ToString(op.MostrarNome(id));
            //lblPessoaDeDestino.Text = op.nome;

            ///////////////////////////////////////////////
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            Lista lista = new Lista();
            lista.ShowDialog();
            lblPessoaDeDestino.Text = lista.userEscolhido2;
            txtIdOutraConta.Text = lista.userEscolhido;
            // pegar o valor escolhido
            AtualizarSaldo();
        }

        #endregion

    }
}
