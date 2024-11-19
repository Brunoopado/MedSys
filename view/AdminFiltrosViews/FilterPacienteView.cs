using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedSys.view.AdminFiltrosViews
{
    public partial class FilterPacienteView : Form
    {
        public FilterPacienteView()
        {
            InitializeComponent();
        }
        public event Action<string, DateTime, string, string, string> EnviarDados;

        void AtualizaValores()
        {
            string nome = txtNome.Text;
            DateTime dtNascimento = dtpDtNascimento.Value;
            string tipoSanguineo = txtTipoSanguineo.Text;
            string cpf = txtCPF.Text;
            string telefone = txtTelefone.Text;

            EnviarDados?.Invoke(nome, dtNascimento, tipoSanguineo, cpf, telefone);
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            AtualizaValores();
        }

        private void dtpDtNascimento_ValueChanged(object sender, EventArgs e)
        {
            AtualizaValores();
        }

        private void txtTipoSanguineo_TextChanged(object sender, EventArgs e)
        {
            AtualizaValores();
        }

        private void txtCPF_TextChanged(object sender, EventArgs e)
        {
            AtualizaValores();
        }

        private void txtTelefone_TextChanged(object sender, EventArgs e)
        {
            AtualizaValores();
        }
    }
}
