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

        ConsultaController consulta = new ConsultaController();

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Consulta cadConsulta = new Consulta();
            Medico cadMedico= new Medico();
            Paciente cadPaciente = new Paciente();

            cadConsulta.InicioConsulta = dtpInicio.Value;
            cadConsulta.FimConsulta = dtpFim.Value;
            cadConsulta.DescricaoConsulta = txtDescricao.Text;
            cadConsulta.Medico = cadMedico;
            cadConsulta.Paciente = cadPaciente;

            consulta.Inserir( cadConsulta);

            
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {

        }

    }
}
