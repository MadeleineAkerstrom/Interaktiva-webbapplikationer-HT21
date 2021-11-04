using interaktiva14.Models;
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
                var task2 = cmdbRepository.GetMovies();
                await Task.WhenAll(task1, task2); // Wait untill all tasks are done. 
                
                var _searchResult = await task1;
                var movies = await task2;

                var searchResult = await omdbRepository.GetMovieInfoAsync(_searchResult);
                var updatedSearchResult = AddLikeDislikeToSearchResult(searchResult, movies);

                var model = new SearchResultViewModel(updatedSearchResult);
                
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
        /// <summary>
        ///  Checks if the search contains any likes or dislikes and adds it to the searchresult if it is so. 
        /// </summary>
        /// <param name="searchResults, movies">List<MovieInformationDto> searchResults, List<ToplistDto> movies</param>
        /// <returns>List<MovieInformationDto></returns>
        private List<MovieInformationDto> AddLikeDislikeToSearchResult(List<MovieInformationDto> searchResults, List<ToplistDto> movies)
        {
            foreach (var searchResult in searchResults)
            {
                foreach (var movie in movies)
                {
                    if (searchResult.imdbID == movie.imdbID)
                    {
                        searchResult.NumberOfDislikes = movie.numberOfDislikes;
                        searchResult.NumberOfLikes = movie.numberOfLikes;
                    }
                }
            }
            return searchResults;
        }
    }
}
