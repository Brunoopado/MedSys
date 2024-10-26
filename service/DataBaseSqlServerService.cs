using System;
using System.Data;
using System.Data.SqlClient;

namespace MedSys.service
{
    public class DataBaseSqlServerService
    {
        private SqlConnection CriarConexao()
        {
            SqlConnection conexao = new SqlConnection();
            //Os dados para conectar no banco
            conexao.ConnectionString = "Data Source=BRUNOPC\\sqlexpress;"//Servidor
                                                       + "Initial Catalog=MEDSYS;"//Nome do banco
                                                       + "Integrated Security=SSPI;"//Autenticação do Windows (usuario logado)
                                                       + "User Instance=false;"; //Usar o usuario da maquina

            conexao.Open(); //Abrir a conexão com o banco
            return conexao;
        }
        // Variavel privada global para armazernar os parametros de comandos SQL
        private SqlParameterCollection sqlParameterCollection = new SqlCommand().Parameters;

        //Método para limpar os parametros
        public void LimparParametros()
        {
            sqlParameterCollection.Clear();
        }

        //Método para adicionar parâmetros
        public void AdicionarParametros(string nomeParametro, object valorParametro)
        {
            sqlParameterCollection.Add(new SqlParameter(nomeParametro, valorParametro));
        }

        //A partir daqui se iniciam as manipulações
        //INSERT, UPDATE E DELETE
        public int ExecutarManipulacao(CommandType commandType, string nomeStorageOuTextoSql)
        {
            try
            {
                //Abro a conexão com o banco
                SqlConnection sqlConnection = CriarConexao();

                //Criar a varial do comando que sera executado
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                //Define o tipo de comando
                sqlCommand.CommandType = commandType;

                //Definimos o comando a ser executado
                sqlCommand.CommandText = nomeStorageOuTextoSql;

                //Carregar os parametros
                foreach (SqlParameter sqlParameter in sqlParameterCollection)
                {
                    sqlCommand.Parameters.AddWithValue(sqlParameter.ParameterName, sqlParameter.Value);
                }

                //Executar o comando no banco de dados
                //coletar o retorno
                //0 - Não conseguiu executar
                //>0 - Registro afetados
                return sqlCommand.ExecuteNonQuery();
            }
            //Se der problema
            //Trata a msg para o usuario
            catch (Exception ex)
            {
                //Crio a mensagem tratada
                throw new Exception("Houve uma falha ao executar o comando no banco de dados.\r\nMensagem original: " + ex.Message);
            }
        }
        //Select retorna uma tabela de dados
        public DataTable ExecutarConsulta(CommandType commandType, string nomeStorageOuTextSql)
        {
            try
            {
                SqlConnection sqlConnection = CriarConexao();

                //Criar a varial do comando que sera executado
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                //Define o tipo de comando
                sqlCommand.CommandType = commandType;

                //Definimos o comando a ser executado
                sqlCommand.CommandText = nomeStorageOuTextSql;

                //Carregar os parametros
                foreach (SqlParameter sqlParameter in sqlParameterCollection)
                {
                    sqlCommand.Parameters.AddWithValue(sqlParameter.ParameterName, sqlParameter.Value);
                }

                //O retorno da consulta é um DataTable
                //O C# precisa que esse DataTable seja um objeto
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();

                //Nesse momento o comando SQL será executado, o retorno é convertido, o comando é executado
                // dentro do dataAdapter e o resultado sera colocado na dataTable
                //Fill == SELECT
                sqlDataAdapter.Fill(dataTable);

                return dataTable;

            }
            catch (Exception ex)
            {
                //Crio a mensagem tratada
                throw new Exception("Houve uma falha ao executar a consulta no banco de dados.\r\nMensagem original: " + ex.Message);
            }
        }
        //Consulta SCALAR
        public object ExecutarConsultaScalar(CommandType commandType, string nomeStorageOuTextoSql)
        {
            try
            {
                //Abro a conexão com o banco
                SqlConnection sqlConnection = CriarConexao();

                //Criar a varial do comando que sera executado
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                //Define o tipo de comando
                sqlCommand.CommandType = commandType;

                //Definimos o comando a ser executado
                sqlCommand.CommandText = nomeStorageOuTextoSql;

                //Carregar os parametros
                foreach (SqlParameter sqlParameter in sqlParameterCollection)
                {
                    sqlCommand.Parameters.AddWithValue(sqlParameter.ParameterName, sqlParameter.Value);
                }

                //Executar o comando no banco de dados
                //coletar o retorno
                //0 - Não conseguiu executar
                //>0 - Registro afetados
                return sqlCommand.ExecuteScalar();
            }
            //Se der problema
            //Trata a msg para o usuario
            catch (Exception ex)
            {
                //Crio a mensagem tratada
                throw new Exception("Houve uma falha ao executar a consulta scalar no banco de dados.\r\nMensagem original: " + ex.Message);
            }
        }
    }
}