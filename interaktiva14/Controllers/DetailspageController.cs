using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace interaktiva14.Controllers
{
    public class DetailspageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
