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
            string testOperator = Request.Form["where"];
            int popNumber = Convert.ToInt32(Request.Form["popNumber"]);
            string order = Request.Form["order"];
            List<City> newCityList = City.FilterPop(testOperator, popNumber, order);

            return View("Index", newCityList);
          }


    }
}
