using Foconet.Data.Entities.Models;
using Foconet.Data.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Foconet.Web.UI.Controllers
{
    public class MaterialController : Controller
    {
        private MaterialService materialService;

        public MaterialController()
        {
            materialService = new MaterialService();
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
        public ActionResult Create(Material material)
        {
            if(ModelState.IsValid)
            {
                materialService.Add(material);

                string url = Url.Action("Index", "Material", new { id = material.Id });
                return Json(new { success = true, url = url });
            }

            return PartialView("_Create", material);
        }

        public ActionResult Edit(int id)
        {
            return PartialView("_Edit", materialService.Find(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Material material)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(address).State = EntityState.Modified;
                //db.SaveChanges();

                //string url = Url.Action("Index", "Addresses", new { id = address.PersonID });
                //return Json(new { success = true, url = url });

                materialService.Update(material);
                string url = Url.Action("Index", "Material", new { id = material.Id });
                return Json(new { success = true, url = url });
            }


            return PartialView("_Edit", material);
        }

        public ActionResult List()
        {
            return PartialView("_List", materialService.GetAll());
        }
    }
}