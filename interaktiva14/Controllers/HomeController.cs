using interaktiva14.Models;
using interaktiva14.Models.ViewModels;
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
            string movieName = "Dune"; // Behöver koppla denna till html interface
            var searchResult = await omdbRepository.GetMovieBySearchAsync(movieName);
            var movieInfo = await omdbRepository.GetMovieByTitleIdAsync("Dune");
            var model = new HomeViewModel(searchResult);
            return View(model);
        }
    }
}
