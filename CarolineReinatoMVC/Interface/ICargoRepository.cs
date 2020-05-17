using CarolineReinatoMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarolineReinatoMVC.Interface
{
    public interface ICargoRepository 
    {
        void Insert(Cargo cargo);
        void Select(int id);
        List<Cargo> GetCargos();
        void Desativar(int id);
        void Ativar(int id);
    }
}
