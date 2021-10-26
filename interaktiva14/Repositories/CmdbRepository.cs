using interaktiva14.Infrastructure;
using interaktiva14.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace interaktiva14.Repositories
{
    public class CmdbRepository : ICmdbRepository
    {
        private readonly IApiClient apiClient;
        private readonly IConfiguration _config;
        private readonly string baseEndpoint = "https://grupp9.dsvkurs.miun.se/api/";

        public CmdbRepository(IApiClient apiClient, IConfiguration config)
        {
            this.apiClient = apiClient;
            _config = config;
        }
        public async Task<MovieBySearchDto> GetMovieBySearch(string movieName)
        {
            var moviesApiKey = _config["Movies:ServiceApiKey"];
            var result = await apiClient.GetAsync<MovieBySearchDto>($"{baseEndpoint}?apikey={moviesApiKey}&s={movieName}&plot=full");
            return result;
        }
    }
}
