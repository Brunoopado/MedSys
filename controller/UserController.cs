using System.Data;
using System;
using MedSys.model;
using MedSys.service;

namespace MedSys.controller
{
    public class UserController
    {
        DataBaseSqlServerService database = new DataBaseSqlServerService();

        public int Inserir(Usuario usuario)
        {
            string queryInserir = "INSERT INTO usuario (cpf_usuario, email_usuario, nome_usuario, nivel_acesso, senha_usuario) " +
                                  "VALUES (@cpf_usuario, @email_usuario, @nome_usuario, @nivel_acesso, @senha_usuario)";

            database.LimparParametros();

            database.AdicionarParametros("@cpf_usuario",    usuario.CPF);
            database.AdicionarParametros("@email_usuario",  usuario.Email);
            database.AdicionarParametros("@nome_usuario",   usuario.Nome);
            database.AdicionarParametros("@nivel_acesso",   usuario.NivelAcesso);
            database.AdicionarParametros("@senha_usuario",  usuario.Senha);

            database.ExecutarManipulacao(CommandType.Text, queryInserir);

            return Convert.ToInt32(database.ExecutarConsultaScalar(CommandType.Text, "SELECT MAX(id_cliente) FROM usuario"));
        }

        public int Alterar(Usuario usuario)
        {
            string quetyAlterar = "UPDATE usuario " +
                                  "SET cpf_usuario = @cpf_usuario, email_usuario = @email_usuario, nome_usuario = @nome_usuario, nivel_acesso = @nivel_acesso, senha_usuario = @senha_usuario" +
                                  "WHERE id_usuario = @id_usuario";

            database.LimparParametros();

            database.AdicionarParametros("@cpf_usuario",    usuario.CPF);
            database.AdicionarParametros("@email_usuario",  usuario.Email);
            database.AdicionarParametros("@nome_usuario",   usuario.Nome);
            database.AdicionarParametros("@nivel_acesso",   usuario.NivelAcesso);
            database.AdicionarParametros("@senha_usuario",  usuario.Senha);

            return database.ExecutarManipulacao(CommandType.Text, quetyAlterar);
        }

        public int Apagar(int IdUsuario)
        {
            string queryApagar = "DELETE FROM usuario WHERE id_usuario = @id_usuario";

            database.LimparParametros();
            database.AdicionarParametros("@id_usuario", IdUsuario);

            return database.ExecutarManipulacao(CommandType.Text, queryApagar);
        }

        public Usuario ConsultarPorId(int IdUsuario)
        {
            string queryConsulta = "SELECT * FROM usuario " +
                                   "WHERE id_cliente = @id_usuario";

            database.LimparParametros();
            database.AdicionarParametros("@id_cliente", IdUsuario);

            DataTable dataTable = database.ExecutarConsulta(CommandType.Text, queryConsulta);

            if (dataTable.Rows.Count > 0)
            {
                Usuario usuario = new Usuario();

                usuario.IdUsuario= Convert.ToInt32(dataTable.Rows[0]["id_cliente"]);
                usuario.CPF = Convert.ToChar(dataTable.Rows[0]["CPF"]);
                usuario.Email = Convert.ToString(dataTable.Rows[0]["email_usuario"]);
                usuario.Nome = Convert.ToString(dataTable.Rows[0]["nome_usuario"]);
                usuario.NivelAcesso = Convert.ToChar(dataTable.Rows[0]["nivel_acesso"]);
                usuario.Senha = Convert.ToString(dataTable.Rows[0]["senha_usuario"]);

                //Após mapeado o objeto, retornar o objeto cliente mapeado
                return usuario;
            }
            else
            {
                return null;
            }
        }

        public Boolean ValidarUsuarioSenha(string NomeUsuario, string SenhaUsuario)
        {
            string queryUsuarioSenha = "SELECT * FROM usuario WHERE nome_usuario = @nome_usuario AND senha_usuario = @senha_usuario";

            database.LimparParametros();
            database.AdicionarParametros("@nome_usuario", NomeUsuario);
            database.AdicionarParametros("@senha_usuario", SenhaUsuario);

            DataTable dataTable = database.ExecutarConsulta(CommandType.Text, queryUsuarioSenha);

            //Verifica se teve um retorno, utilizando operador ternário
            return dataTable.Rows.Count > 0 ? true : false;
        }
    }
}