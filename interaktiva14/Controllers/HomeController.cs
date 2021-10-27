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
                
                string movieName = "Dune"; // Behöver koppla denna till html interface
                var task1 = omdbRepository.GetMovieBySearchAsync(movieName);
                var task2 = omdbRepository.GetMovieByTitleAsync(movieName);
                var task3 = cmdbRepository.GetMovieToplist();

                await Task.WhenAll(task1, task2, task3); // Väntar till alla uppgifter har kört klart. 
                
                var _searchResult = await task1;
                var movieInfo = await task2;
                
                var top4 = await task3;

                var model = new HomeViewModel(_searchResult, movieInfo);
                
                //var model = new HomeViewModel();
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
        
        
        private List<MovieResultDto> CombineMovieInfo(){
            var movies = new List<MovieResultDto>();
            return movies;
        }
    }
}
