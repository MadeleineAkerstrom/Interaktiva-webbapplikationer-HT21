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
        private ICmdbRepository cmdbRepository;

        public HomeController(IOmdbRepository omdbRepository, ICmdbRepository cmdbRepository)
        {
            this.omdbRepository = omdbRepository;
            this.cmdbRepository = cmdbRepository;
        }
       
        public async Task<IActionResult> Index()
        {
            //var searchResult = await omdbRepository.GetSearchResultMovieInfo("Dune");
            try
            {
                var task3 = cmdbRepository.GetMovieToplist();
                await Task.WhenAll(task3); // Väntar till alla uppgifter har kört klart. 
                var top5 = await task3;
                var toplist = await omdbRepository.GetMovieInfo(null);
                var model = new HomeViewModel(toplist);
                
                return View(model);
            }
            catch (System.Exception)
            {
                var model = new HomeViewModel();
                ModelState.AddModelError(string.Empty, "Fick inte kontakt med OMDb statistiken");
                return View(model);
                throw;
            }
        }
    }
}
