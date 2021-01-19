using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConexaoBanco
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Funcionario f = new Funcionario();
            f.idFuncionario = Convert.ToInt32(txtidFuncionario.Text);
            f.Nome = txtNome.Text;
            f.Salvar();

        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            Funcionario f = new Funcionario();
            GridDados.DataSource = f.Pesquisar();
            

        }
    }
}
