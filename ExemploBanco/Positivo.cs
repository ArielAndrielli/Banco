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
    public partial class Positivo : Form
    {
        public Positivo(DadosLogin dadosLogin)
        {
            InitializeComponent();
            this.dadosLogin = dadosLogin;
        }

        private DadosLogin dadosLogin = null;

        private void btnAceito_Click(object sender, EventArgs e)
        {
            Close();

            
        }

    }
}
