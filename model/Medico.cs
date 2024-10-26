using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedSys.model
{
    public class Medico
    {
        public int IdMedico { get; set; }
        public string CRM { get; set; }
        public string Especialidade { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Telefone { get; set; }
        public string Nome { get; set; }

        // Relação com Usuario
        public Usuario Usuario { get; set; }
    }

}
