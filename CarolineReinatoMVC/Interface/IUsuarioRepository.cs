using CarolineReinatoMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarolineReinatoMVC.Interface
{
    public interface IUsuarioRepository
    {
        List<Usuario> GetUsuarios();
        List<Cargo> DropDownCargos();
        void Insert(Usuario usuario);
        void Select(int id);
        void Desativar(int id);
        void Ativar(int id);
        bool LoginValidacao(string nome);
    }
}
