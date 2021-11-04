using interaktiva14.Infrastructure;
using interaktiva14.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace interaktiva14.Repositories
{
    public class OmdbRepository : IOmdbRepository
    {
        private readonly IApiClient apiClient;
        private readonly IConfiguration _config;
        private readonly string baseEndpoint = "http://www.omdbapi.com/";
        private readonly string moviesApiKey;
        

        public OmdbRepository(IApiClient apiClient, IConfiguration config)
        {
            this.apiClient = apiClient;
            _config = config;
            moviesApiKey = _config["Movies:ServiceApiKey"];
        }

        /// <summary>
        /// Get list of search result by movie name 
        /// </summary>
        /// <param name="movieName">Name of movie</param>
        /// <returns>MovieSearchDto</returns>
        public async Task<MovieBySearchDto> GetMovieBySearchAsync(string movieName)
        {
            var result = await apiClient.GetAsync<MovieBySearchDto>($"{baseEndpoint}?apikey={moviesApiKey}&s={movieName}&plot=full");
            return result;
        }

        /// <summary>
        /// Search movie with title from OMDb. Return movies together with full plot
        /// </summary>
        /// <param name="movieName">Movie name</param>
        /// <returns>MovieInformationDto</returns>
        public async Task<MovieInformationDto> GetMovieByTitleAsync(string movieName)
        {
            var result = await apiClient.GetAsync<MovieInformationDto>($"{baseEndpoint}?apikey={moviesApiKey}&t={movieName}&plot=full");
            return result;
        }

        /// <summary>
        /// Search movie with imdbID from OMDb. Return movies together with full plot
        /// </summary>
        /// <param name="movieName">Movie imdbID</param>
        /// <returns>MovieInformationDto</returns>
        public async Task<MovieInformationDto> GetMovieByIdAsync(string movieName)
        {
            var result = await apiClient.GetAsync<MovieInformationDto>($"{baseEndpoint}?apikey={moviesApiKey}&i={movieName}&plot=full");
            return result;
        }

        /// <summary>
        /// Get movie info from CMDb with number of likes+dislikes
        /// </summary>
        /// <param name="result">List of imdbID result</param>
        /// <returns>MovieInformationDto</returns>
        public async Task<List<MovieInformationDto>> GetMovieInfoAsync(MovieBySearchDto result) //  List<imdbID> result
        {
            var tasks = new List<Task>();
            var movies = new List<MovieInformationDto>();
            try
            {
                foreach (var movie in result.Search)
                {
                    tasks.Add(
                        Task.Run(
                            async () =>
                            {
                                var movieInfo = await GetMovieByIdAsync(movie.imdbID);
                                movieInfo.NumberOfLikes = movie.NumberOfLikes;
                                movieInfo.NumberOfDislikes = movie.NumberOfDislikes; 
                                movies.Add(movieInfo);
                            }
                        )
                    );
                };
                await Task.WhenAll(tasks);
            }
            catch (System.Exception)
            { 
                throw;
            }
            return movies;
        }
    }
}
