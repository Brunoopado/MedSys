using System;

namespace MedSys.model
{
    public class Tratamento
    {
        public int IdTratamento { get; set; }
        public DateTime DtInicio { get; set; }
        public DateTime DtFim { get; set; }
        public string DescTratamento { get; set; }

        //Relacionamento com Consulta
        public Consulta Consulta { get; set; }
    }
}
