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
            try     
            {
                var top5 = await cmdbRepository.GetMovieToplist();
                
                var movie = ConvertToMovieBySearch(top5);

                var toplistInfo = await omdbRepository.GetMovieInfoAsync(movie);
                var model = new HomeViewModel(toplistInfo);
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
        /// <summary>
        ///  Returns top5 converted to MovieBySearchDto object
        /// </summary>
        /// <param name="top5">top5</param>
        /// <returns>MovieBySearchDto</returns>
        private MovieBySearchDto ConvertToMovieBySearch(List<ToplistDto> top5)
        {
            var search = new List<MovieDto>();

            foreach (var toplistMovie in top5)
            {
                MovieDto movieDto = new MovieDto(){
                    imdbID = toplistMovie.imdbID,
                    NumberOfLikes = toplistMovie.numberOfLikes,
                    NumberOfDislikes = toplistMovie.numberOfDislikes                    
                };
                search.Add(movieDto);
            }

            MovieBySearchDto movieBySearchDto = new MovieBySearchDto(){
                Search = search
            };
            return movieBySearchDto;
        }
    }
}
