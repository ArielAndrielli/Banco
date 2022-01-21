using ExemploBanco.Login;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExemploBanco.Login
{
    public partial class I_Cadastro : Form
    {

        #region Construtor

        public I_Cadastro()
        {
            InitializeComponent();
        }

        #endregion

        #region Atributos

        private Log_in oCadastro = new Log_in();
        HashCode hc = new HashCode();

        #endregion

        #region Eventos

        private void btnLogin_Click(object sender, EventArgs e)
        {
            #region Verificações

            HashCode hs = new HashCode();

            if (txtUsuario.Text.Trim() == "Usuário"
                || txtSenha.Text.Trim() == "Senha"
                || txtConfSenha.Text.Trim() == "Confirmar Senha")
            {
                MessageBox.Show("Campos obrigatórios", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            if (txtConfSenha.Text != txtSenha.Text)
            {
                MessageBox.Show("As senhas não batem! Verifique e tente novamente.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            #endregion

            #region Operação

            oCadastro.Nome = txtUsuario.Text.Trim();
            oCadastro.Senha = hc.PassHash(txtSenha.Text.Trim());
            oCadastro.Cadastrar();

            if (oCadastro.HasError)
            {
                MessageBox.Show(oCadastro.MsgError, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            MessageBox.Show("Usuário cadastrado com sucesso!",
                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Hide();

            #endregion
        }

        private void txtUsuario_Click(object sender, EventArgs e)
        {
            txtUsuario.ForeColor = Color.Black;

            if(txtUsuario.Text == "Usuário")
            {
                txtUsuario.Text = string.Empty;
            }
            else
            {
                txtUsuario.Text = txtUsuario.Text;
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if(txtUsuario.Text == string.Empty)
            {
                txtUsuario.ForeColor = Color.Gray;
                txtUsuario.Text = "Usuário";
            }
        }

        private void txtSenha_Click(object sender, EventArgs e)
        {
            txtSenha.ForeColor = Color.Black;

            txtSenha.PasswordChar = '*';
            if (txtSenha.Text == "Senha")
            {
                txtSenha.Text = string.Empty;
            }
            else
            {
                txtSenha.Text = txtSenha.Text;
            }
            txtSenha.ForeColor = Color.Black;
            txtSenha.PasswordChar = '*';
        }

        private void txtSenha_Leave(object sender, EventArgs e)
        {
            if(txtSenha.Text == string.Empty)
            {
                txtSenha.Text = "Senha";
                txtSenha.ForeColor = Color.Gray;
                txtSenha.PasswordChar = '\u0000';
            }
            else
            {
                txtSenha.Text = txtSenha.Text;
            }

        }

        private void txtConfSenha_Click(object sender, EventArgs e)
        {
            if (txtConfSenha.Text == "Confirmar Senha")
            {
                txtConfSenha.Text = string.Empty;
            }
            else
            {
                txtConfSenha.Text = txtConfSenha.Text;
            }
            txtConfSenha.ForeColor = Color.Black;
            txtConfSenha.PasswordChar = '*';
        }

        private void txtConfSenha_Leave(object sender, EventArgs e)
        {
            if(txtConfSenha.Text == string.Empty)
            {
                txtConfSenha.Text = "Confirmar Senha";
                txtConfSenha.ForeColor = Color.Gray;
                txtConfSenha.PasswordChar = '\u0000';
            }
            else
            {
                txtConfSenha.Text = txtConfSenha.Text;
            }

        }

        #endregion

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            txtUsuario.ForeColor = Color.Black;

            if (txtUsuario.Text == "Usuário")
            {
                txtUsuario.Text = string.Empty;
            }
            else
            {
                txtUsuario.Text = txtUsuario.Text;
            }
        }

        private void txtSenha_Enter(object sender, EventArgs e)
        {
            if (txtSenha.Text == "Senha")
            {
                txtSenha.Text = string.Empty;
            }
            else
            {
                txtSenha.Text = txtSenha.Text;
            }
            txtSenha.ForeColor = Color.Black;
            txtSenha.PasswordChar = '*';
        }

        private void txtConfSenha_Enter(object sender, EventArgs e)
        {
            if (txtConfSenha.Text == "Confirmar Senha")
            {
                txtConfSenha.Text = string.Empty;
            }
            else
            {
                txtConfSenha.Text = txtConfSenha.Text;
            }
            txtConfSenha.ForeColor = Color.Black;
            txtConfSenha.PasswordChar = '*';
        }
    }
}
