using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TesteOxxy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void sairMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void novoCadastroMenu_Click(object sender, EventArgs e)
        {
            Cadastro.FormCadastro frm = new Cadastro.FormCadastro();
            frm.ShowDialog();
        }
    }
}
