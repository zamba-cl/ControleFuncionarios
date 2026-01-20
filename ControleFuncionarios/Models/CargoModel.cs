using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleFuncionarios.Models
{
    public class CargoModel
    {
        public int idCargo { get; set; }
        public string nomeCargo { get; set; }
        public decimal salario { get; set; }
    }
}