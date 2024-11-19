using System;
using System.Windows.Forms;

namespace MedSys.view.AdminFiltrosViews
{
    public partial class FilterUsuarioView : Form
    {
        public FilterUsuarioView()
        {
            InitializeComponent();
        }
        public event Action<string, string, string, int?> EnviarDados;

        void AtualizaValores()
        {
            string nome = txtNome.Text;
            string cpf = txtCPF.Text;
            string email = txtEmail.Text;
            int nivelAcesso = string.IsNullOrEmpty(cbbNivelAcesso.SelectedItem?.ToString()) ? -1 : int.Parse(cbbNivelAcesso.SelectedItem.ToString());

            EnviarDados?.Invoke(nome, cpf, email, nivelAcesso);
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            AtualizaValores();
        }
        private void txtId_TextChanged(object sender, EventArgs e)
        {
            AtualizaValores();
        }
        private void txtCPF_TextChanged(object sender, EventArgs e)
        {
            AtualizaValores();
        }
        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            AtualizaValores();
        }
        private void cbbNivelAcesso_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizaValores();
        }
    }
}
