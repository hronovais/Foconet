using Foconet.Data.Entities.Models;
using Foconet.Data.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Foconet.Web.UI.Controllers
{
    public class PedidoItensController : Controller
    {
        private PedidoService pedidoService;
        private PedidoItensService pedidoItensService;
        private MaterialService materialService;

        public PedidoItensController()
        {
            pedidoService = new PedidoService();
            pedidoItensService = new PedidoItensService();
            materialService = new MaterialService();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List(int id)
        {
            ViewBag.PedidoId = id;
            var pedidoItens = pedidoItensService.Get(id);
            return PartialView("_List", pedidoItens);
        }

        public ActionResult Create(int pedidoId)
        {

            var materiais = materialService.GetAll().Select(x => new { MaterialId = x.Id, Nome = x.Nome });
            ViewBag.Materiais = new SelectList(materiais, "MaterialId", "Nome");


            return PartialView("_Create");
        }

        [HttpPost]
        public ActionResult Create(PedidoItens pedidoItens)
        {
            if(pedidoItensService.ExistePedidoNaoFinalizadoParaMaterial(pedidoItens.MaterialId))
            {
                ModelState.AddModelError(string.Empty, @"Existe pedido não finalizado para o material.");
            }   

            if (ModelState.IsValid)
            {
                pedidoItensService.Add(pedidoItens);

                string url = Url.Action("List", "PedidoItens", new { id = pedidoItens.PedidoId });
                return Json(new { success = true, url = url });
            }

            var materiais = materialService.GetAll().Select(x => new { MaterialId = x.Id, Nome = x.Nome });
            ViewBag.Materiais = new SelectList(materiais, "MaterialId", "Nome");

            return PartialView("_Create", pedidoItens);
        }

        public ActionResult Edit(int id)
        {
            var materiais = materialService.GetAll().Select(x => new { MaterialId = x.Id, Nome = x.Nome });
            ViewBag.Materiais = new SelectList(materiais, "MaterialId", "Nome");

             return PartialView("_Edit", pedidoItensService.Find(id));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PedidoItens pedidoItens)
        {
            if (ModelState.IsValid)
            {
                pedidoItensService.Update(pedidoItens);
                string url = Url.Action("List", "PedidoItens", new { id = pedidoItens.PedidoId });
                return Json(new { success = true, url = url });
            }

            return PartialView("_Edit", pedidoItens);
        }

        public ActionResult Delete(int id)
        {
            PedidoItens pedidoItem = pedidoItensService.Find(id);

            if (pedidoItem == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Delete", pedidoItem);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PedidoItens pedidoItem = pedidoItensService.Find(id);
            pedidoItensService.Delete(pedidoItem);

            string url = Url.Action("List", "PedidoItens", new { id = pedidoItem.PedidoId });
            return Json(new { success = true, url = url });

        }
    }
}