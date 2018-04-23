using MVCxGridViewDataBinding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Q556797.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GridPartial() {
            var model = MyModel.GetModelList();
            return PartialView(model);
        } 
    }
}
