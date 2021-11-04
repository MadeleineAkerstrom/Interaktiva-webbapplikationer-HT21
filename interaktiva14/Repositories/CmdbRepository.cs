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
        private readonly string baseEndpoint = "https://grupp9.dsvkurs.miun.se/api";
        
        public CmdbRepository(IApiClient apiClient)
        {
            this.apiClient = apiClient;
        }
        /// <summary>
        /// Gets top 5 movies from CMDb. Sorted in descending order based on ratings.
        /// </summary>
        /// <returns>ToplistDto</returns>
        public async Task<List<ToplistDto>> GetMovieToplist()
        {
            var top5 = "Toplist?sort=desc&count=5&type=ratings";
            var result = await apiClient.GetAsync<List<ToplistDto>>($"{baseEndpoint}/{top5}");
            return result;  
        }
        /// <summary>
        /// Gets movies from CMDb. Sorted in descending order.
        /// </summary>
        /// <returns>ToplistDto</returns>
        public async Task<List<ToplistDto>> GetMovies()
        {
            var result = await apiClient.GetAsync<List<ToplistDto>>($"{baseEndpoint}/Toplist?sort=desc");
            return result;  
        }
    }
}
