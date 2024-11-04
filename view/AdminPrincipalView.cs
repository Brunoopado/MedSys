using System;
using System.Windows.Forms;
using MedSys.view.AdminFiltrosViews;

namespace MedSys.view
{
    public partial class AdminPrincipalView : Form
    {
        public AdminPrincipalView()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string formulário = cbbEntidade.Text.ToUpper();

            switch (formulário)
            {
                case "USUÁRIOS":
                    FilterUsuarioView form = new FilterUsuarioView();
                    form.TopLevel = false;
                    form.FormBorderStyle = FormBorderStyle.None;
                    pnlFiltro.Controls.Add(form);
                    form.Show();
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TextBox txtNome = (TextBox)pnlFiltro.Controls.Find("txtNome", true)[0];
            string nome = txtNome.Text;

            lblTeste.Text = nome;
        }
    }
}
