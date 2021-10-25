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
        public async Task<IActionResult> Index()
        {
            string movieName = "Dune";
            var searchResult = await omdbRepository.GetMovieBySearch(movieName);
            return View(searchResult);
        }
    }
}
