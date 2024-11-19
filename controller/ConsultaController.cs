using System.Data;
using System;
using MedSys.model;
using MedSys.service;
using System.Collections.Generic;

namespace MedSys.controller
{
    public class ConsultaController
    {
        DataBaseSqlServerService database = new DataBaseSqlServerService();
        MedicoController medicocontroller = new MedicoController();
        PacienteController pacientecontroller = new PacienteController();
        UserController usercontroller = new UserController();

        public int Inserir(Consulta consulta)
        {
            string queryInserir = "INSERT INTO Consulta (id_consulta, inicio_consulta, id_paciente, id_medico, descricao_consulta, fim_consulta, id_usuario) " +
                              "VALUES (@id_consulta, @inicio_consulta, @id_paciente, @id_medico, @descricao_consulta, @fim_consuta, @id_usuario)";

            database.LimparParametros();
            database.AdicionarParametros("@id_consulta",             consulta.IdConsulta);
            database.AdicionarParametros("@inicio_consulta",         consulta.InicioConsulta);
            database.AdicionarParametros("@id_paciente",             consulta.Paciente.IdPaciente);
            database.AdicionarParametros("@id_medico",               consulta.Medico.IdMedico);
            database.AdicionarParametros("@descricao_consulta",      consulta.DescricaoConsulta);
            database.AdicionarParametros("@fim_consulta",            consulta.FimConsulta);
            database.AdicionarParametros("@id_usuario",              consulta.Usuario.IdUsuario);

            database.ExecutarManipulacao(CommandType.Text, queryInserir);

            return Convert.ToInt32(database.ExecutarConsultaScalar(CommandType.Text, "SELECT MAX(id_consulta) FROM Consulta"));

        }

        public int Alterar(Consulta consulta)
        {
            string queryAlterar = "UPDATE Consulta " +
                               "SET inicio_consulta = @inicio_consulta, id_paciente = @id_paciente, id_medico = @id_medico, " +
                               "descricao_consulta = @descricao_consulta, fim_consulta = @fim_consulta, id_usuario = @id_usuario " +
                               "WHERE id_consulta = @id_consulta";

            database.LimparParametros();
            database.AdicionarParametros("@inicio_consulta",         consulta.InicioConsulta);
            database.AdicionarParametros("@id_paciente",             consulta.Paciente.IdPaciente);
            database.AdicionarParametros("@id_medico",               consulta.Medico.IdMedico);
            database.AdicionarParametros("@descricao_consulta",      consulta.DescricaoConsulta);
            database.AdicionarParametros("@fim_consulta",            consulta.FimConsulta);
            database.AdicionarParametros("@id_usuario",              consulta.Usuario.IdUsuario);
            database.AdicionarParametros("@id_consulta",             consulta.IdConsulta);

            return database.ExecutarManipulacao(CommandType.Text, queryAlterar);
        }

        public int Apagar(int IdConsulta)
        {
            string queryApagar = "DELETE FROM Consulta WHERE id_consulta = @id_consulta";

            database.LimparParametros();
            database.AdicionarParametros("@id_consulta", IdConsulta);

            return database.ExecutarManipulacao(CommandType.Text, queryApagar);
        }

        public Consulta ConsultarPorId(int idConsulta)
        {
            string queryConsulta = "SELECT * FROM Consulta WHERE id_consulta = @id_consulta";

            database.LimparParametros();
            database.AdicionarParametros("@id_consulta", idConsulta);

            DataTable dataTable = database.ExecutarConsulta(CommandType.Text, queryConsulta);

            if (dataTable.Rows.Count > 0)
            {
                Consulta consulta = new Consulta
                { 
                
                    IdConsulta = Convert.ToInt32(dataTable.Rows[0]["id_consulta"]),
                    DescricaoConsulta = Convert.ToString(dataTable.Rows[0]["descricao_consulta"]),
                    InicioConsulta = Convert.ToDateTime(dataTable.Rows[0]["inicio_consulta"]),
                    FimConsulta= Convert.ToDateTime(dataTable.Rows[0]["fim_consulta"]),


                };

                return consulta;
            }
            else
            {
                return null;
            }
        }
        // Consultar Consultas por período
        public ConsultaCollection ConsultarPorPeriodo(DateTime dtInicial, DateTime dtFinal)
        {
            ConsultaCollection consultaCollection = new ConsultaCollection();

            string query = "SELECT * FROM Consulta WHERE inicio_consulta BETWEEN @DtInicial AND @DtFinal";

            DateTime dtInicialZeroHoras = new DateTime(dtInicial.Year, dtInicial.Month, dtInicial.Day, 00, 00, 00);
            DateTime dtFinalUltimaHora = new DateTime(dtFinal.Year, dtFinal.Month, dtFinal.Day, 23, 59, 59);

            database.LimparParametros();
            database.AdicionarParametros("@DtInicial", dtInicialZeroHoras);
            database.AdicionarParametros("@DtFinal", dtFinalUltimaHora);

            DataTable dataTable = database.ExecutarConsulta(CommandType.Text, query);

            foreach (DataRow dataRow in dataTable.Rows)
            {
                Consulta consulta = new Consulta
                {
                    IdConsulta = Convert.ToInt32(dataRow["id_consulta"]),
                    InicioConsulta = Convert.ToDateTime(dataRow["inicio_consulta"]),
                    FimConsulta = (DateTime)(dataRow["fim_consulta"] as DateTime?),
                    DescricaoConsulta = Convert.ToString(dataRow["descricao_consulta"])
                };

                //// Associações com entidades externas (se necessário)
                //consulta.Paciente = new Paciente { IdPaciente = Convert.ToInt32(dataRow"id_paciente"]) };
                consulta.Paciente = pacientecontroller.ConsultarPorId(Convert.ToInt32(dataRow["id_paciente"]));
                //consulta.Medico = new Medico { IdMedico = Convert.ToInt32(dataRow["id_medico"]) };
                consulta.Medico = medicocontroller.ConsultarPorId(Convert.ToInt32(dataRow["id_medico"]));
                //consulta.Usuario = new Usuario { IdUsuario = Convert.ToInt32(dataRow["id_usuario"]) };
                consulta.Usuario = usercontroller.ConsultarPorId(Convert.ToInt32(dataRow["id_usuario"]));

                consultaCollection.Add(consulta);
            }

            return consultaCollection;
        }
        public List<Medico> ObterMedicos()
        {
            string query = "SELECT id_medico, nome FROM Medico";
            DataTable medicoDataTable = database.ExecutarConsulta(CommandType.Text, query);

            List<Medico> medicos = new List<Medico>();

            foreach (DataRow row in medicoDataTable.Rows)
            {
                Medico medico = new Medico
                {
                    IdMedico = Convert.ToInt32(row["id_medico"]),
                    Nome = row["nome"].ToString()
                };
                medicos.Add(medico);
            }

            return medicos;
        }
    }
}