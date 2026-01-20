using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleFuncionarios.Models
{
    public class FeriasModel
    {
        public int idFerias {  get; set; }
        public DateTime dtInicio { get; set; }
        public DateTime dtTermino { get; set; }
        public int statusFerias { get; set; }
        public int idFuncionario { get; set; }
    }
}