using System.Data;
using System;
using MedSys.model;
using MedSys.service;

namespace MedSys.controller
{
    public class ConsultaController
    {
        DataBaseSqlServerService database = new DataBaseSqlServerService();

        public int Inserir(Consulta consulta, Paciente paciente, Medico medico)
        {
            string queryInserir = "INSERT INTO Consulta (id_consulta, data_consulta, id_paciente, id_medico, descricao_consulta, dt_criacao, id_usuario) " +
                              "VALUES (@id_consulta, @data_consulta, @id_paciente, @id_medico, @descricao_consulta, @dt_criacao, @id_usuario)";

            database.LimparParametros();
            database.AdicionarParametros("@id_consulta",         consulta.IdConsulta);
            database.AdicionarParametros("@data_consulta",       consulta.DataConsulta);
            database.AdicionarParametros("@id_paciente",         consulta.Paciente.IdPaciente);
            database.AdicionarParametros("@id_medico",           consulta.Medico.IdMedico);
            database.AdicionarParametros("@descricao_consulta",  consulta.DescricaoConsulta);
            database.AdicionarParametros("@dt_criacao",          consulta.DataCriacao);
            database.AdicionarParametros("@id_usuario",          consulta.Usuario.IdUsuario);

            database.ExecutarManipulacao(CommandType.Text, queryInserir);

            return Convert.ToInt32(database.ExecutarConsultaScalar(CommandType.Text, "SELECT MAX(id_consulta) FROM Consulta"));

        }

        public int Alterar(Consulta consulta, Paciente paciente, Medico medico)
        {
            string queryAlterar = "UPDATE Consulta " +
                               "SET data_consulta = @data_consulta, id_paciente = @id_paciente, id_medico = @id_medico, " +
                               "descricao_consulta = @descricao_consulta, dt_alteracao = @dt_alteracao, id_usuario = @id_usuario " +
                               "WHERE id_consulta = @id_consulta";

            database.LimparParametros();
            database.AdicionarParametros("@data_consulta",           consulta.DataConsulta);
            database.AdicionarParametros("@id_paciente",             consulta.Paciente.IdPaciente);
            database.AdicionarParametros("@id_medico",               consulta.Medico.IdMedico);
            database.AdicionarParametros("@descricao_consulta",      consulta.DescricaoConsulta);
            database.AdicionarParametros("@dt_alteracao",            DateTime.Now);
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
                    DataConsulta = Convert.ToDateTime(dataTable.Rows[0]["data_consulta"]),
                    DescricaoConsulta = Convert.ToString(dataTable.Rows[0]["descricao_consulta"]),
                    DataCriacao = Convert.ToDateTime(dataTable.Rows[0]["dt_criacao"]),
                    DataAlteracao = dataTable.Rows[0]["dt_alteracao"] as DateTime?,
                };

                return consulta;
            }
            else
            {
                return null;
            }
        }
    }
}