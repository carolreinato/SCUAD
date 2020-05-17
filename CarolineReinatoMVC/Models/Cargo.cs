using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarolineReinatoMVC.Models
{
    public class Cargo
    {
        public int Id { get; set; }
        public string NomeCargo { get; set; }
        public bool StatusAtivo { get; set; }
    }
}