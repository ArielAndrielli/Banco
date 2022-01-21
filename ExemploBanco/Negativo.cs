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
    public partial class Negativo : Form
    {
        public Negativo()
        {
            InitializeComponent();
        }

        private void btnNegado_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
