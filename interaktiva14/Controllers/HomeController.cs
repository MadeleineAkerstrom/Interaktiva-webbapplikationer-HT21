using interaktiva14.Models;
using interaktiva14.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace interaktiva14.Controllers
{
    public class HomeController : Controller
    {
        private IOmdbRepository omdbRepository;

        public HomeController(IOmdbRepository omdbRepository)
        {
            this.omdbRepository = omdbRepository;
        }
        public IActionResult Index()
        {
            var searchResult = omdbRepository.GetMovieBySearch();
            return View(searchResult);
        }
    }
}
