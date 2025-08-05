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
    public partial class frm_cadaluno : Form
    {
        public frm_cadaluno()
        {
            InitializeComponent();
            alunosBD  obj_aluno_bd = new alunosBD();
            txtnome.Text = "";
            txtendereco.Text = "";
            txtidade.Text = "";
            txtnome.Focus();
            dataGridView1.DataSource = obj_aluno_bd.getAlunos();

        }
      

        private void btnSalvar_Click_1(object sender, EventArgs e)
        {
            if (txtnome.Text.Equals(""))
            {
                MessageBox.Show("Informe o nome do aluno.");
                return;
            }
            try
            {
                alunosBD obj_aluno_bd = new alunosBD();
                alunos alunoReg = new alunos(txtnome.Text, txtendereco.Text, int.Parse(txtidade.Text));
                obj_aluno_bd.IncluirAluno(alunoReg);
                MessageBox.Show("Registro salvo com sucesso");
                btnLimpar.PerformClick();
            }
            catch (Exception c)
            {
                MessageBox.Show(c.ToString());
            }
        }

        private void btnfechar_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLimpar_Click_1(object sender, EventArgs e)
        {
            alunosBD obj_aluno_bd = new alunosBD();
            txtnome.Clear();
            txtendereco.Clear();
            txtidade.Clear();
            txtnome.Focus();
            dataGridView1.DataSource = obj_aluno_bd.getAlunos();
        }
    }
}
