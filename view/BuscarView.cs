using System;
using System.Windows.Forms;
using MedSys.controller;
using MedSys.model;
using MedSys.view.AdminFiltrosViews;

namespace MedSys.view
{
    public partial class BuscarView : Form
    {
        public BuscarView()
        {
            InitializeComponent();
        }

        //variáveis globais populadas pelos inputs no filtro
        //Médico
        string crm_medico;
        string nome_medico;
        string telefone_medico;
        string especialidade_medico;

        //Paciente
        string nome_paciente;
        DateTime dtNascimento_paciente;
        string tipoSanguineo_paciente;
        string cpf_paciente;
        string telefone_paciente;

        //Usuario
        string nome_usuario;
        string cpf_usuario;
        string email_usuario;
        int? nivelAcesso_usuario;

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            switch (cbbFilter.Text)
            {
                case "Pacientes":
                    CasePaciente(nome_paciente, tipoSanguineo_paciente, cpf_paciente, dtNascimento_paciente, telefone_paciente);
                    break;
                case "Médicos":
                    CaseMedicos(crm_medico, nome_medico, telefone_medico, especialidade_medico);
                    break;
                case "Usuários":
                    CaseUsuario(nome_usuario, cpf_usuario, email_usuario, nivelAcesso_usuario);
                    break;
            }
            void CasePaciente(string nome, string tipo_sanguineo, string cpf, DateTime dt_nascimento, string telefone)
            {
                PacienteController PacienteController = new PacienteController();
                PacientefCollection PacienteResultado = new PacientefCollection();

                PacienteResultado = PacienteController.ConsultaPorFiltro(nome, tipo_sanguineo, cpf, dt_nascimento, telefone);
                lsbResultados.DataSource = PacienteResultado;
            }
            void CaseUsuario(string nome, string cpf, string email, int? nivelAcesso)
            {
                UserController controller = new UserController();
                UsuarioCollection resultado = controller.ConsultaPorFiltro(cpf, email, nome, nivelAcesso);

                lsbResultados.DataSource = resultado;
                foreach(Usuario usuario in resultado)
                {
                    Console.WriteLine(usuario.ToString());
                }
            }
            void CaseMedicos(string nome, string crm, string especialidade, string telefone)
            {
                MedicoController controller = new MedicoController();
                MedicoCollection resultado = new MedicoCollection();

                resultado = controller.ConsultaPorFiltro(nome, crm, especialidade, telefone);
                lsbResultados.DataSource = resultado;
            }
        }

        private void cbbFilter_SelectedValueChanged(object sender, EventArgs e)
        {
            switch (cbbFilter.Text)
            {
                case "Pacientes":
                    FilterPacienteView frmPaciente = new FilterPacienteView();
                    frmPaciente.EnviarDados += ReceberDados_Pacientes;

                    pnlFiltro.Controls.Clear();
                    frmPaciente.AutoSize = true;
                    frmPaciente.Size = pnlFiltro.Size;
                    frmPaciente.TopLevel = false;
                    pnlFiltro.Controls.Add(frmPaciente);
                    frmPaciente.Show();

                    pnlFiltro.Controls.Add(frmPaciente);

                    void ReceberDados_Pacientes(string nome, DateTime dtNascimento, string tipoSanguineo, string cpf, string telefone)
                    {
                        string nome_paciente = nome;
                        DateTime dtNascimento_paciente = dtNascimento;
                        string tipoSanguineo_paciente = tipoSanguineo;
                        string cpf_paciente = cpf;
                        string telefone_paciente = telefone;
                    }
                    break;

                case "Médicos":
                    FilterMedicoView frmMedico = new FilterMedicoView();
                    frmMedico.EnviarDados += ReceberDados_Medicos;

                    pnlFiltro.Controls.Clear();
                    frmMedico.AutoSize = true;
                    frmMedico.Size = pnlFiltro.Size;
                    frmMedico.TopLevel = false;
                    pnlFiltro.Controls.Add(frmMedico);
                    frmMedico.Show();

                    pnlFiltro.Controls.Add(frmMedico);

                    void ReceberDados_Medicos(string crm, string nome, string telefone, string especialidade)
                    {
                        crm_medico = crm;
                        nome_medico = nome;
                        telefone_medico = telefone;
                        especialidade_medico = especialidade;
                    }
                    break;

                case "Usuários":
                    FilterUsuarioView frmUsuario = new FilterUsuarioView();
                    frmUsuario.EnviarDados += ReceberDados_Usuario;

                    pnlFiltro.Controls.Clear();
                    frmUsuario.AutoSize = true;
                    frmUsuario.Size = pnlFiltro.Size;
                    frmUsuario.TopLevel = false;
                    pnlFiltro.Controls.Add(frmUsuario);
                    frmUsuario.Show();

                    pnlFiltro.Controls.Add(frmUsuario);

                    void ReceberDados_Usuario(string nome, string cpf, string email, int? nivelAcesso)
                    {
                        nome_usuario = nome;
                        cpf_usuario = cpf;
                        email_usuario = email;
                        nivelAcesso_usuario = nivelAcesso;
                    }
                    break;
            }
        }
    }
}
