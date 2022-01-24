﻿using Banco;
using System;
using System.Windows.Forms;

namespace ExemploBanco
{
    public partial class Deposito : Form
    {
        #region Construtor

          public Deposito(DadosLogin dadosLogin)
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
            double saldo = op.MostrarSaldo(dadosLogin.id_login); //verifica se aqui volta um double, se não voltar, faz o convert double

            lblSaldo.Text = "R$ " + saldo.ToString("N2"); //isso vai formatar pra ficar com 2 casas decimais e com pontuação
        }

        private void Deposito_Load(object sender, EventArgs e)
        {
            AtualizarSaldo();
        }

        private void btnDepositar_Click(object sender, EventArgs e)
        {
            op.id = dadosLogin.id_login;

            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("Campo Obrigatório!");
                return;
            }

            if (System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "[^0-9]"))
            {
                MessageBox.Show("Valor Inválido!");
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
                textBox1.Text = string.Empty;
                return;
            }

            op.saldo = double.Parse(textBox1.Text.Trim());

            if (op.saldo < 1)
            {
                MessageBox.Show("Valor Inválido!");
                return;
            }
            else
            {
            op.Depositar();
            }

            if (op.HasError)
            {
                MessageBox.Show(op.MsgError, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            else
            {
                MessageBox.Show("Depósito realizado com sucesso!",
                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DialogResult dg = MessageBox.Show("Deseja realizar outro depósito?", "Pergunta",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dg == DialogResult.Yes)
                {
                    AtualizarSaldo();
                    textBox1.Text = string.Empty;
                    return;
                }
                else
                {
                    this.Close();
                }
            }

            

        }

        #endregion
    }
}
