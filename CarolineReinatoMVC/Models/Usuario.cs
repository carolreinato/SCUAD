using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using System.Web.Mvc;

namespace CarolineReinatoMVC.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public int IdCargo { get; set; }
        public string Nome { get; set; }
        public bool StatusAtivo { get; set; }
        public string NomeCargo { get; set; }
    }
}