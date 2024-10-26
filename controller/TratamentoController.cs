using System.Data;
using System;
using MedSys.model;
using MedSys.service;

namespace MedSys.controller
{
    public class TratamentoController
    {
        DataBaseSqlServerService database = new DataBaseSqlServerService();

        public int Inserir(Tratamento tratamento, Consulta consulta, Paciente paciente, Medico medico)
        {
            string queryInserir = "INSERT INTO Tratamento (id_paciente, id_medico, id_consulta, dt_inicio, dt_fim, descricao_tratamento) " +
                              "VALUES (@id_paciente, @id_medico, @id_consulta, @dt_inicio, @dt_fim, @descricao_tratamento)";

            database.LimparParametros();
            database.AdicionarParametros("@id_paciente",            tratamento.Consulta.Paciente.IdPaciente);
            database.AdicionarParametros("@id_medico",              tratamento.Consulta.Medico.IdMedico);
            database.AdicionarParametros("@id_consulta",            tratamento.Consulta.IdConsulta);
            database.AdicionarParametros("@dt_inicio",              consulta.Medico.IdMedico);
            database.AdicionarParametros("@dt_fim",                 consulta.DescricaoConsulta);
            database.AdicionarParametros("@descricao_tratamento",   consulta.DataCriacao);

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
            database.AdicionarParametros("@data_consulta", consulta.DataConsulta);
            database.AdicionarParametros("@id_paciente", consulta.Paciente.IdPaciente);
            database.AdicionarParametros("@id_medico", consulta.Medico.IdMedico);
            database.AdicionarParametros("@descricao_consulta", consulta.DescricaoConsulta);
            database.AdicionarParametros("@dt_alteracao", DateTime.Now);
            database.AdicionarParametros("@id_usuario", consulta.Usuario.IdUsuario);
            database.AdicionarParametros("@id_consulta", consulta.IdConsulta);

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
                    IdPaciente = Convert.ToInt32(dataTable.Rows[0]["id_paciente"]),
                    IdMedico = Convert.ToInt32(dataTable.Rows[0]["id_medico"]),
                    DescricaoConsulta = Convert.ToString(dataTable.Rows[0]["descricao_consulta"]),
                    DataCriacao = Convert.ToDateTime(dataTable.Rows[0]["dt_criacao"]),
                    DataAlteracao = dataTable.Rows[0]["dt_alteracao"] as DateTime?,
                    IdUsuario = Convert.ToInt32(dataTable.Rows[0]["id_usuario"])
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