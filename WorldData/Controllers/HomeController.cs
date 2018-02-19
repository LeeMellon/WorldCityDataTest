using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WorldData.Models;
using System;

namespace WorldData.Controllers
{
    public class HomeController : Controller
    {
      [HttpGet("/")]
          public ActionResult Index()
          {
            List<City> newCityList = City.GetAll();
            return View(newCityList);

          }
          [HttpPost("/filter")]
          public ActionResult Result()
          {
            string beginsWith = Request.Form["beginsWith"];
            string operators = Request.Form["operators"];
            int popNumber = Convert.ToInt32(Request.Form["popNumber"]);
            string namePop = Request.Form["namePop"];
            string order = Request.Form["order"];

            List<City> newCityList = City.FilterPop(beginsWith, operators, popNumber,namePop,  order);

            return View("Index", newCityList);
          }


    }
}
