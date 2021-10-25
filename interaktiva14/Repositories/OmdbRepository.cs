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

        public OmdbRepository(IApiClient apiClient, IConfiguration config)
        {
            this.apiClient = apiClient;
            _config = config;
        }
        public async Task<MovieBySearchDto> GetMovieBySearch(string movieName)
        {
            var moviesApiKey = _config["Movies:ServiceApiKey"];
            var result =await apiClient.GetAsync<MovieBySearchDto>($"{baseEndpoint}?apikey={moviesApiKey}&s={movieName}&plot=full");
            return result;
        }
    }
}
