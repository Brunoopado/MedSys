using System;

namespace MedSys.model
{
    public class Consulta
    {
        public int IdConsulta { get; set; }
        public DateTime InicioConsulta { get; set; }
        public DateTime FimConsulta { get; set; }

        public string DescricaoConsulta { get; set; }

        // Relação com Classes Externas
        public Paciente Paciente { get; set; }
        public Medico Medico { get; set; }
        public Usuario Usuario { get; set; }

        //Retorno concatenado
        public string DataMedicoPaciente {
            get
            {
                return InicioConsulta.Hour + " - " + Medico.Nome + " - " + Paciente.Nome;
            } 
        }
    }

}
