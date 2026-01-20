using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleFuncionarios.Models
{
    public class AlteracaoModel
    {
        public int idAlteracao { get; set; }
        public DateTime dtHrAlteracao { get; set; }
        public string campoAlterado { get; set; }
        public string valorAntigo {  get; set; }
        public string valorNovo {  get; set; }
        public int idFuncionario { get; set; }
    }
}