﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Technicality.AspNetTrainingOne;

namespace Technicality.AspNetTrainingOne.Controllers
{
    public class KendoCityController : Controller
    {
        private TrainingOneContext db = new TrainingOneContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cities_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<City> cities = db.Cities;
            DataSourceResult result = cities.ToDataSourceResult(request, city => new {
                CityId = city.CityId,
                CityName = city.CityName,
                State = city.State
            });

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Cities_Create([DataSourceRequest]DataSourceRequest request, City city)
        {
            if (ModelState.IsValid)
            {
                var entity = new City
                {
                    CityName = city.CityName,
                    State = city.State
                };

                db.Cities.Add(entity);
                db.SaveChanges();
                city.CityId = entity.CityId;
            }

            return Json(new[] { city }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Cities_Update([DataSourceRequest]DataSourceRequest request, City city)
        {
            if (ModelState.IsValid)
            {
                var entity = new City
                {
                    CityId = city.CityId,
                    CityName = city.CityName,
                    State = city.State
                };

                db.Cities.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(new[] { city }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Cities_Destroy([DataSourceRequest]DataSourceRequest request, City city)
        {
            if (ModelState.IsValid)
            {
                var entity = new City
                {
                    CityId = city.CityId,
                    CityName = city.CityName,
                    State = city.State
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
