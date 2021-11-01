using interaktiva14.Models.ViewModels;
using interaktiva14.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace interaktiva14.Controllers
{
    public class SearchResultController : Controller
    {
        private IOmdbRepository omdbRepository;
        private ICmdbRepository cmdbRepository;
        public SearchResultController(IOmdbRepository omdbRepository, ICmdbRepository cmdbRepository)
        {
            this.omdbRepository = omdbRepository;
            this.cmdbRepository = cmdbRepository;
        }
        public async Task<IActionResult> Index(string searchMovieName)
        {
            try
            {
                var task1 = omdbRepository.GetMovieBySearchAsync(searchMovieName);

                await Task.WhenAll(task1); // Väntar till alla uppgifter har kört klart. 
                
                var _searchResult = await task1;

                var searchResult = await omdbRepository.GetMovieInfoAsync(_searchResult);
                var model = new SearchResultViewModel(searchResult);
                
                return View(model);
            }
            catch (System.Exception)
            {
                var model = new SearchResultViewModel();
                ModelState.AddModelError(string.Empty, "Fick inte kontakt med OMDb statistiken");
                return View(model);
                throw;
            }
        }

        public IActionResult Like()
        {
            return Content("Hello World");
        }
    }
}
