using System;

namespace MedSys.model
{
    public class Consulta
    {
        public int IdConsulta { get; set; }
        public DateTime DataConsulta { get; set; }
        public string DescricaoConsulta { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public DateTime? DataAlteracao { get; set; }

        // Relação com Classes Externas
        public Paciente Paciente { get; set; }
        public Medico Medico { get; set; }
        public Usuario Usuario { get; set; }

        //Retorno concatenado
        public string DataMedicoPaciente {
            get
            {
                return DataConsulta.Hour + " - " + Medico.Nome + " - " + Paciente.Nome;
            } 
        }
    }

}
