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
    public class CargoController : Controller
    {

        private ICargoRepository _cargoRepository;
        public CargoController()
        {
            this._cargoRepository = new CargoRepository();
        }

        // GET: Cargo
        public ActionResult Index()
        {
            var cargos = _cargoRepository.GetCargos();
            return View(cargos);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create (Cargo cargo)
        {
            _cargoRepository.Insert(cargo);
            return RedirectToAction("Index");
        }
        public ActionResult Desativar(int id)
        {
            _cargoRepository.Desativar(id);
            return RedirectToAction("Index");
        }
        public ActionResult Ativar(int id)
        {
            _cargoRepository.Ativar(id);
            return RedirectToAction("Index");
        }
    }
}