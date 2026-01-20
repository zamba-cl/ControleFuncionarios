using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleFuncionarios.Models
{
    public class FuncionarioModel
    {
        public int idFuncionario { get; set; }
        public string nomeFuncionario { get; set; }
        public DateTime dtAdmissao { get; set; }
        public int statusFuncionario { get; set; }
        public int idCargo { get; set; }
    }
}