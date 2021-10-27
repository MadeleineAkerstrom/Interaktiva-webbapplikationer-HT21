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
        public async Task<MovieBySearchDto> GetMovieBySearchAsync(string movieName)
        {
            var result = await apiClient.GetAsync<MovieBySearchDto>($"{baseEndpoint}?apikey={moviesApiKey}&s={movieName}&plot=full");
            return result;
        }

        public async Task<MovieByTitleIdDto> GetMovieByTitleAsync(string movieName)
        {
            var result = await apiClient.GetAsync<MovieByTitleIdDto>($"{baseEndpoint}?apikey={moviesApiKey}&t={movieName}&plot=full");
            return result;
        }

        public async Task<MovieByTitleIdDto> GetMovieByIdAsync(string movieName)
        {
            var result = await apiClient.GetAsync<MovieByTitleIdDto>($"{baseEndpoint}?apikey={moviesApiKey}&t={movieName}&plot=full");
            return result;
        }

        public async Task<IEnumerable<MovieResultDto>> GetMovieResultDto()
        {
            return null;
        }
    }
}
