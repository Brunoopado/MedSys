using System;
using System.Data;
using MedSys.model;
using MedSys.service;

namespace MedSys.controller
{
    public class MedicoController
    {
        DataBaseSqlServerService database = new DataBaseSqlServerService();
        Medico medico = new Medico();

        public int Inserir(Medico medico)
        {
            string queryInserir = "INSERT INTO Medico (id_medico, crm, especialidade, dt_cadastro, telefone, nome, id_usuario) " +
                                  "VALUES (@IdMedico, @CRM, @Especialidade, @DataCadastro, @Telefone, @Nome, @Id_usuario)";

            database.LimparParametros();

            database.AdicionarParametros("@IdMedico",       medico.IdMedico);
            database.AdicionarParametros("@CRM",            medico.CRM);
            database.AdicionarParametros("@Especialidade",  medico.Especialidade);
            database.AdicionarParametros("@DataCadastro",   medico.DataCadastro);
            database.AdicionarParametros("@Telefone",       medico.Telefone);
            database.AdicionarParametros("@IdUsuario",      medico.Usuario.IdUsuario);

            database.ExecutarManipulacao(CommandType.Text, queryInserir);

            return Convert.ToInt32(database.ExecutarConsultaScalar(CommandType.Text, "SELECT MAX(id_cliente) FROM cliente"));
        }

        public int Alterar(Medico medico)
        {
            string queryAlterar = "UPDATE Medico " +
                                  "SET nome = @Nome, crm = @CRM, especialidade = @Especialidade, dt_cadastro = @DataCadastro, telefone = @Telefone " +
                                  "WHERE IdMedico = @id_medico";

            database.LimparParametros();

            database.AdicionarParametros("@IdMedico",           medico.IdMedico);
            database.AdicionarParametros("@CRM",                medico.CRM);
            database.AdicionarParametros("@Especialidade",      medico.Especialidade);
            database.AdicionarParametros("@DatCadastro",        medico.DataCadastro);
            database.AdicionarParametros("@Telefone",           medico.Telefone);
            database.AdicionarParametros("@IdUsuario",          medico.Usuario.IdUsuario);

            return database.ExecutarManipulacao(CommandType.Text, queryAlterar);
        }

        public int Apagar(int IdMedico)
        {
            string queryApagar = "DELETE FROM cliente WHERE id_medico = @IdMedico";

            database.LimparParametros();
            database.AdicionarParametros("@IdMedico", IdMedico);

            return database.ExecutarManipulacao(CommandType.Text, queryApagar);
        }

        public Medico ConsultarPorId(int IdMedico)
        {
            UserController usuController = new UserController();

            string queryConsulta = "SELECT * FROM Medico " +
                                   "WHERE id_medico = @IdMedico";

            database.LimparParametros();
            database.AdicionarParametros("@IdMedico", IdMedico);

            DataTable dataTable = database.ExecutarConsulta(CommandType.Text, queryConsulta);

            if (dataTable.Rows.Count > 0)
            {
                Medico medico = new Medico();

                medico.IdMedico = Convert.ToInt32(dataTable.Rows[0]["id_medico"]);
                medico.Nome = Convert.ToString(dataTable.Rows[0]["nome"]);
                medico.CRM = Convert.ToString(dataTable.Rows[0]["crm"]);
                medico.Especialidade = Convert.ToString(dataTable.Rows[0]["especialidade"]);
                medico.DataCadastro = Convert.ToDateTime(dataTable.Rows[0]["dt_cadastro"]);
                medico.Telefone = Convert.ToString(dataTable.Rows[0]["telefone"]);
                medico.Usuario = usuController.ConsultarPorId(Convert.ToInt32(dataTable.Rows[0]["id_usuario"]));

                return medico;
            }
            else
            {
                return null;
            }
        }
    }
}