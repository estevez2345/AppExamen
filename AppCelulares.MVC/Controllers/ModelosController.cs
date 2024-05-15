using AppCelulares.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AppCelulares.ConsumeAPI;
using System.Runtime.InteropServices;

namespace AppCelulares.MVC.Controllers
{
    public class ModelosController : Controller
    {
        private string urlApi;

        public ModelosController(IConfiguration configuration)
        {
            urlApi = configuration.GetValue("ApiUrlBase", "").ToString() + "/Modelos";
        }

        // GET: ModelosController
        public ActionResult Index()
        {
            var data = Crud<Modelo>.Read(urlApi);
            return View(data);
        }

        // GET: ModelosController/Details/5
        public ActionResult Details(int id)
        {
            var data = Crud<Modelo>.Read_ById(urlApi, id);
            return View(data);
        }

        // GET: ModelosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ModelosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Modelo data)
        {
            try
            {
                var newData = Crud<Modelo>.Create(urlApi, data);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }

        // GET: ModelosController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = Crud<Modelo>.Read_ById(urlApi, id);
            return View(data);
        }

        // POST: ModelosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Modelo data)
        {
            try
            {
                Crud<Modelo>.Update(urlApi, id, data);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }

        // GET: ModelosController/Delete/5    
        public ActionResult Delete(int id)
        {
            var data = Crud<Modelo>.Read_ById(urlApi, id);
            return View(data);
        }

        // POST: ModelosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Modelo data)
        {
            try
            {
                Crud<Modelo>.Delete(urlApi, id);
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
