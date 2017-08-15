using Foconet.Data.Entities.Models;
using Foconet.Data.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Foconet.Web.UI.Controllers
{
    public class ClienteController : Controller
    {
        private ClienteService clienteService;

        public ClienteController()
        {
            clienteService = new ClienteService();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return PartialView("_Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cliente cliente)
        {
            if(ModelState.IsValid)
            {
                clienteService.Add(cliente);

                string url = Url.Action("Index", "Cliente", new { id = cliente.Id });
                return Json(new { success = true, url = url });
            }

            return PartialView("_Create", cliente);
        }

        public ActionResult Edit(int id)
        {
            return PartialView("_Edit", clienteService.Find(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                clienteService.Update(cliente);
                string url = Url.Action("Index", "Cliente", new { id = cliente.Id });
                return Json(new { success = true, url = url });
            }

            return PartialView("_Edit", cliente);
        }

        public ActionResult List()
        {
            return PartialView("_List", clienteService.GetAll());
        }
    }
}