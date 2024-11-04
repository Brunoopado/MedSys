using System;
using System.Windows.Forms;

namespace MedSys.view
{
    public partial class RecepcionistaPrincipalView : Form
    {
        public RecepcionistaPrincipalView()
        {
            InitializeComponent();
            txtUserLogado.Text = "1 - LUCAS";
        }

        private void RecepcionistaPrincipalView_Load(object sender, EventArgs e)
        {

        }

        private void lsbDia1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            CadastroConsultaView Cadastrar = new CadastroConsultaView();
            Cadastrar.Show();

        }
    }
}
