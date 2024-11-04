using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MedSys.controller;
using MedSys.model;

namespace MedSys.view
{
    public partial class CadastroConsultaView : Form
    {
        public CadastroConsultaView()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            ConsultaController consulta = new ConsultaController();
            Consulta cadConsulta = new Consulta();
            Medico cadMedico= new Medico();
            Paciente cadPaciente = new Paciente();
            consulta.Inserir( cadConsulta, cadPaciente,  cadMedico);

            
        }
    }
}
