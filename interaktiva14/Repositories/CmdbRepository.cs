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
        private readonly string baseEndpoint = "https://grupp9.dsvkurs.miun.se/api/";

        public CmdbRepository(IApiClient apiClient)
        {
            this.apiClient = apiClient;
        }
        public async Task<CmdbDto> GetMovieToplist()
        {
            var top4 = "Toplist?sort=desc&count=4&type=popularity";
            var result = await apiClient.GetAsync<CmdbDto>($"{baseEndpoint}{top4}");
            return result; // returnerar sökresultat med  imdbID, måste sedan använda sig av omdbAPI för att få titel mm.. 
        }
    }
}
