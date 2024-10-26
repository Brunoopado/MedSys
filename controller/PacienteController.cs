using System;
using System.Data;
using MedSys.model;
using MedSys.service;

namespace MedSys.controller
{
    public class PacienteController
    {
        DataBaseSqlServerService database = new DataBaseSqlServerService();
        Paciente paciente = new Paciente();

        public int Inserir(Paciente paciente)
        {
            string queryInserir = "INSERT INTO Paciente (id_paciente, nome, tipo_sanguineo , dt_nascimento, telefone, cpf) " +
                                  "VALUES (@IdPaciente, @Nome, @TipoSanguineo, @DataNascimento, @Telefone, @CPF)";

            database.LimparParametros();

            database.AdicionarParametros("@IdPaciente",         paciente.IdPaciente);
            database.AdicionarParametros("@Nome",               paciente.Nome);
            database.AdicionarParametros("@TipoSanguineo",      paciente.TipoSanguineo);
            database.AdicionarParametros("@DataNascimento",     paciente.DataNascimento);
            database.AdicionarParametros("@Telefone",           paciente.Telefone);
            database.AdicionarParametros("@CPF",                paciente.CPF);

            database.ExecutarManipulacao(CommandType.Text, queryInserir);

            return Convert.ToInt32(database.ExecutarConsultaScalar(CommandType.Text, "SELECT MAX(id_paciente) FROM paciente"));
        }

        public int Alterar(Paciente paciente)
        {
            string quetyAlterar = "UPDATE Paciente " +
                                  "SET nome = @Nome, tipo_sanguineo = @TipoSanguineo, dt_nascimento = @DataNascimento,telefone = @Telefone, cpf = @CPF " +
                                  "WHERE id_paciente = @IdPaciente";

            database.LimparParametros();

            database.AdicionarParametros("@IdPaciente",        paciente.IdPaciente);
            database.AdicionarParametros("@TipoSanguineo",     paciente.TipoSanguineo);
            database.AdicionarParametros("@Nome",              paciente.Nome);
            database.AdicionarParametros("@DataNascimento",    paciente.DataNascimento);
            database.AdicionarParametros("@Telefone",          paciente.Telefone);
            database.AdicionarParametros("CPF",                paciente.CPF);

            return database.ExecutarManipulacao(CommandType.Text, quetyAlterar);
        }

        public int Apagar(int IdPaciente)
        {
            string queryApagar = "DELETE FROM paciente WHERE id_paciente = @IdPaciente";

            database.LimparParametros();
            database.AdicionarParametros("@IdPaciente", IdPaciente);

            return database.ExecutarManipulacao(CommandType.Text, queryApagar);
        }

        public Paciente ConsultarPorId(int IdPaciente)
        {
            UserController usuController = new UserController();

            string queryConsulta = "SELECT * FROM Paciente " +
                                   "WHERE id_paciente = @IdPaciente";

            database.LimparParametros();
            database.AdicionarParametros("@IdPaciente", IdPaciente);

            DataTable dataTable = database.ExecutarConsulta(CommandType.Text, queryConsulta);

            if (dataTable.Rows.Count > 0)
            {
                Paciente paciente = new Paciente();

                paciente.IdPaciente = Convert.ToInt32(dataTable.Rows[0]["id_paciente"]);
                paciente.Nome = Convert.ToString(dataTable.Rows[0]["nome"]);
                paciente.TipoSanguineo = Convert.ToString(dataTable.Rows[0]["tipo_sanguineo"]);
                paciente.CPF = Convert.ToString(dataTable.Rows[0]["cpf"]);
                paciente.DataNascimento = Convert.ToDateTime(dataTable.Rows[0]["dt_nascimento"]);
                paciente.Telefone = Convert.ToString(dataTable.Rows[0]["telefone"]);

                return paciente;
            }
            else
            {
                return null;
            }
        }
    }
}