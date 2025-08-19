using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Aluno
{
    public partial class frm_login : Form
    {
        public frm_login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtusuario.Clear();
            txtsenha.Clear();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnentrar_Click(object sender, EventArgs e)
        {
            usuarioBD  usuariobd = new usuarioBD();
            usuario user = usuariobd.selecionaUser(txtusuario.Text, txtsenha.Text);
            if(String.IsNullOrEmpty(user.Nome))
            {
                MessageBox.Show("Usuário ou senha inválidos");
            } else
            {
                frm_cadaluno f2 = new frm_cadaluno();
                this.Hide();
                f2.ShowDialog();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
