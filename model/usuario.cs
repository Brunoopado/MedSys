namespace MedSys.model
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public char CPF { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public char NivelAcesso { get; set; }
        public string Senha { get; set; }
    }
}
