using System;
using System.Windows.Forms;

namespace MedSys.view.AdminFiltrosViews
{
    public partial class FilterMedicoView : Form
    {
        public event Action<string, string, string, string> EnviarDados;
        
        public FilterMedicoView()
        {
            InitializeComponent();
        }
        private void atualizaValores()
        {
            string crm = txtCrm.Text;
            string nome = txtNome.Text;
            string telefone = txtTelefone.Text;
            string especialidade = txtEspecialidade.Text;

            EnviarDados?.Invoke(crm, nome, telefone, especialidade);
        }

        private void txtCrm_TextChanged(object sender, EventArgs e)
        {
            atualizaValores();
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            atualizaValores();
        }

        private void txtTelefone_TextChanged(object sender, EventArgs e)
        {
            atualizaValores();
        }

        private void txtEspecialidade_TextChanged(object sender, EventArgs e)
        {
            atualizaValores();
        }
    }
}
