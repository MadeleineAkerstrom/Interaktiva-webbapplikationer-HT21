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
        public async Task<IActionResult> Index()
        {
            //var searchResult = await omdbRepository.GetSearchResultMovieInfo("Dune");
            try
            {
                string movieName = "Titanic"; // Behöver koppla denna till html interface
                var task1 = omdbRepository.GetMovieBySearchAsync(movieName);

                await Task.WhenAll(task1); // Väntar till alla uppgifter har kört klart. 
                
                var _searchResult = await task1;

                var searchResult = await omdbRepository.GetMovieInfo(_searchResult);
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            var task1 = omdbRepository.GetMovieBySearchAsync("ssdfs");
            // Here's where you do stuff.
        }

    }
}
