using CarolineReinatoMVC.Interface;
using CarolineReinatoMVC.Interface;
using CarolineReinatoMVC.Models;
using CarolineReinatoMVC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarolineReinatoMVC.Controllers
{
    public class UsuarioController : Controller
    {
        private IUsuarioRepository _usuarioRepository;
        public UsuarioController()
        {
            this._usuarioRepository = new UsuarioRepository();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string nome)
        {
            var isUsuarioValido = _usuarioRepository.LoginValidacao(nome);

            return isUsuarioValido ? RedirectToAction("Index", "Home") : RedirectToAction("Error");
            
        }
        public ActionResult Error()
        {
            return View();
        }

        public ActionResult Index()
        {
            var usuarios = _usuarioRepository.GetUsuarios();
            return View(usuarios);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var dropDownCargos = _usuarioRepository.DropDownCargos();
            ViewData["IdCargo"] = new SelectList(dropDownCargos, "Id", "NomeCargo");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Usuario usuario)
        {
            _usuarioRepository.Insert(usuario);
            return RedirectToAction("Index");
        }

        public ActionResult Desativar(int id)
        {
            _usuarioRepository.Desativar(id);
            return RedirectToAction("Index");
        }

        public ActionResult Ativar(int id)
        {
            _usuarioRepository.Ativar(id);
            return RedirectToAction("Index");
        }
    }
}