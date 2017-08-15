using Foconet.Data.Entities.Models;
using Foconet.Data.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Foconet.Web.UI.Controllers
{
    public class PedidoController : Controller
    {
        private PedidoService pedidoService;
        private ClienteService clienteService;
        private MaterialService materialService;
        private PedidoItensService pedidoItensService;

        public PedidoController()
        {
            pedidoService = new PedidoService();
            materialService = new MaterialService();
            clienteService = new ClienteService();
            pedidoItensService = new PedidoItensService();
        }

        public ActionResult Index()
        {
            return View(pedidoService.GetAll());
        }

        public ActionResult Create()
        {
            var clientes = clienteService.GetAll().Select(x => new { ClienteId = x.Id, Nome = x.Nome });

            ViewBag.Clientes = new SelectList(clientes, "ClienteId", "Nome");

            return View("Create");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                pedidoService.Add(pedido);
                return RedirectToAction("Index");
            }

            return PartialView("_Create", pedido);
        }

        public ActionResult Edit(int id)
        {
            var pedido = pedidoService.Find(id);

            var clientes = clienteService.GetAll().Select(x => new { ClienteId = x.Id, Nome = x.Nome });

            ViewBag.Clientes = new SelectList(clientes, "ClienteId", "Nome", pedido.ClienteId);

            return View(pedido);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Pedido pedido)
        {
            var itens = pedidoItensService.Get(pedido.Id);

            var clientes = clienteService.GetAll().Select(x => new { ClienteId = x.Id, Nome = x.Nome });

            ViewBag.Clientes = new SelectList(clientes, "ClienteId", "Nome", pedido.ClienteId);

            if (itens.Count <= 0 && pedido.Finalizado == true)
            {
                ModelState.AddModelError(string.Empty, @"Para salvar um pedido é necessário adicionar os materiais.");
                return View("Edit", pedido);
            }

            if (ModelState.IsValid)
            {
                pedidoService.Update(pedido);
                return RedirectToAction("List");
            }

            return View("Edit", pedido);
 
        }

        public ActionResult List()
        {
            return View("List", pedidoService.GetAll());
        }
    }
}