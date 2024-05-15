using AppCelulares.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AppCelulares.ConsumeAPI;
using System.Runtime.InteropServices;

namespace AppCelulares.MVC.Controllers
{
    public class CelularesController : Controller
    {
        private string urlApi;

        public CelularesController(IConfiguration configuration)
        {
            urlApi = configuration.GetValue("ApiUrlBase", "").ToString() + "/Celulares";
        }

        // GET: CelularesController
        public ActionResult Index()
        {
            var data = Crud<Celular>.Read(urlApi);
            return View(data);
        }

        // GET: CelularesController/Details/5
        public ActionResult Details(int id)
        {
            var data = Crud<Celular>.Read_ById(urlApi, id);
            return View(data);
        }

        // GET: CelularesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CelularesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Celular data)
        {
            try
            {
                var newData = Crud<Celular>.Create(urlApi, data);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }

        // GET: CelularesController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = Crud<Celular>.Read_ById(urlApi, id);
            return View(data);
        }

        // POST: CelularesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Celular data)
        {
            try
            {
                Crud<Celular>.Update(urlApi, id, data);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }

        // GET: CelularesController/Delete/5    
        public ActionResult Delete(int id)
        {
            var data = Crud<Celular>.Read_ById(urlApi, id);
            return View(data);
        }

        // POST: CelularesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Celular data)
        {
            try
            {
                Crud<Celular>.Delete(urlApi, id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }
    }
}
