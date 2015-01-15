using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using States;

namespace Traders_Marketplace.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            ViewBag.Resgister = new OrderState().Register();
            ViewBag.Dispatched = new OrderState().Dispatch();
            ViewBag.Approved = new OrderState().Approve();
            ViewBag.NewOrder = new OrderState()._CurrentState.NewOrderPlaced();
            return View();
        }

        public ActionResult About()
        {
            return View();
        }


    }
}
