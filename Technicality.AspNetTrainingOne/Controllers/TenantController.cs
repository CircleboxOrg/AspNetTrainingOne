using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Technicality.AspNetTrainingOne;
using System.Data.Entity;

namespace Technicality.AspNetTrainingOne.Controllers
{
    public class TenantController : Controller
    {
        private TrainingOneContext db = new TrainingOneContext();

        // GET: Tenant
        public ActionResult Index(string tenantAlias)
        {
            ViewBag.TenantAlias = tenantAlias;
            return View();
        }

        public ActionResult Cities_Read([DataSourceRequest]DataSourceRequest request, string id)
        {
            var cities = from c in db.Cities
                         where c.State == id
                         select c;

            DataSourceResult result = cities.ToDataSourceResult(request, city => new {
                CityId = city.CityId,
                CityName = city.CityName,
                State = city.State
            });

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Cities_Create([DataSourceRequest]DataSourceRequest request, City city, string tenantAlias)
        {
            if (ModelState.IsValid)
            {
                var entity = new City
                {
                    CityName = city.CityName,
                    State = tenantAlias
                };

                db.Cities.Add(entity);
                db.SaveChanges();
                city.CityId = entity.CityId;
            }

            return Json(new[] { city }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Cities_Update([DataSourceRequest]DataSourceRequest request, City city, string tenantAlias)
        {
            if (ModelState.IsValid)
            {
                var entity = new City
                {
                    CityId = city.CityId,
                    CityName = city.CityName,
                    State = tenantAlias
                };

                db.Cities.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(new[] { city }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Cities_Destroy([DataSourceRequest]DataSourceRequest request, City city, string tenantAlias)
        {
            if (ModelState.IsValid)
            {
                var entity = new City
                {
                    CityId = city.CityId,
                    CityName = city.CityName,
                    State = tenantAlias
                };

                db.Cities.Attach(entity);
                db.Cities.Remove(entity);
                db.SaveChanges();
            }

            return Json(new[] { city }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public ActionResult Excel_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }

        [HttpPost]
        public ActionResult Pdf_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}