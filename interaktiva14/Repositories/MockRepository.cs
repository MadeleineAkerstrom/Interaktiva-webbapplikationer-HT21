using System;
using System.IO;
using System.Threading.Tasks;
using interaktiva14.Models;
using interaktiva14.Repositories;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;

namespace DemoInteraktiva.Repositories
{
    public class MockRepository : IOmdbRepository, ICmdbRepository
    {
        private readonly string basePath;
        public MockRepository(IWebHostEnvironment environment)
        {
            basePath = $@"{environment.ContentRootPath}\Mock\"; // hämtar den absoluta sökvägen 
        }

        public async Task<MovieByTitleIdDto> GetMovieByIdAsync(string movieName)
        {
            await Task.Delay(0);
            return GetTestData<MovieByTitleIdDto>("movieByTitle.json");
        }

        public async Task<MovieBySearchDto> GetMovieBySearchAsync(string movieName)
        {
            await Task.Delay(0);
            return GetTestData<MovieBySearchDto>("movieSearch.json");
        }

        public async Task<MovieByTitleIdDto> GetMovieByTitleAsync(string movieName)
        {
            await Task.Delay(0);
            return GetTestData<MovieByTitleIdDto>("movieByTitle.json");
        }
        public async Task<CmdbDto> GetMovieToplist()
        {
            await Task.Delay(0);
            return GetTestData<CmdbDto>("top5.json"); // returnerar sökresultat med  imdbID, måste sedan använda sig av omdbAPI för att få titel mm.. 
        }

        private T GetTestData<T>(string testfile)
        {
            var path = $"{basePath}{testfile}";
            string data = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<T>(data);
        }
    }
}