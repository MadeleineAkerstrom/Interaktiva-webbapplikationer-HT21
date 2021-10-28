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
                var top5 = await task3;

                var test = AddMovieInformation(_searchResult);
                var model = new HomeViewModel(_searchResult, movieInfo, top5);
                
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

        private async Task<List<MovieResultDto>> AddMovieInformation(MovieBySearchDto result)
        {
            var tasks = new List<Task>();
            var movies = new List<MovieResultDto>();
            foreach (var movie in result.Search)
            {
                tasks.Add(
                    Task.Run(
                        async () =>
                        {
                            var movieInfo = await omdbRepository.GetMovieByIdAsync(movie.imdbID);
                            MovieResultDto movieResultDto = new MovieResultDto()
                            {
                                Title = movieInfo.Title,
                                Plot = movieInfo.Plot,
                                imdbID = movieInfo.imdbID
                            };
                            movies.Add(movieResultDto);
                        }
                    )
                );
            };
            await Task.WhenAll(tasks);
            return movies;
        }
    }
}
