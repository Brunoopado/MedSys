using System;

namespace MedSys.model
{
    public class Paciente
    {
        public int IdPaciente { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string TipoSanguineo { get; set; } // Enum: 'A+', 'A-', 'B+', 'B-', 'AB+', 'AB-', 'O+', 'O-'
        public string CPF { get; set; }
        public string Telefone { get; set; }
    }

}
