using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MedSys.view.AdminFiltrosViews;

namespace MedSys.view
{
    public partial class BuscarView : Form
    {
        public BuscarView()
        {
            InitializeComponent();
        }

        FilterUsuarioView frmFilterUser = new FilterUsuarioView();

        private void button1_Click(object sender, EventArgs e)
        {
            
            pnlFiltro.Controls.Clear();
            frmFilterUser.AutoSize = true;
            frmFilterUser.Size = pnlFiltro.Size;
            frmFilterUser.TopLevel = false;
            pnlFiltro.Controls.Add(frmFilterUser);
            frmFilterUser.Show();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("O filtro é: " + frmFilterUser.nome + " - " + frmFilterUser.textBox2.Text);

            FrmTeste frm = new FrmTeste(frmFilterUser.nome);
            panel1.Controls.Clear();
            frm.AutoSize = true;
            frm.Size = pnlFiltro.Size;
            frm.TopLevel = false;
            panel1.Controls.Add(frm);
            frm.Show();
        }
    }
}
