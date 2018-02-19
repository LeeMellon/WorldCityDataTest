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
            // City newCity = new City();
            List<City> newCityList = City.GetAll();
            return View("Index", newCityList);

          }
          [HttpPost("/")]
          public ActionResult Result()
          {

            return View();
          }


    }
}
