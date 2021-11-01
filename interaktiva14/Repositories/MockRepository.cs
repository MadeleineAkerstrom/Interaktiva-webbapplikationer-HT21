using System;
using System.Collections.Generic;
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

        public async Task<MovieInformationDto> GetMovieByIdAsync(string movieName)
        {
            await Task.Delay(0);
            return GetTestData<MovieInformationDto>("movieByTitle.json");
        }

        public async Task<MovieBySearchDto> GetMovieBySearchAsync(string movieName)
        {
            await Task.Delay(0);
            return GetTestData<MovieBySearchDto>("movieSearch.json");
        }

        public async Task<MovieInformationDto> GetMovieByTitleAsync(string movieName)
        {
            await Task.Delay(0);
            return GetTestData<MovieInformationDto>("movieByTitle.json");
        }
        public async Task<List<ToplistDto>> GetMovieToplist()
        {
            await Task.Delay(0);
            return GetTestData<List<ToplistDto>>("top5.json"); // returnerar sökresultat med  imdbID, måste sedan använda sig av omdbAPI för att få titel mm.. 
        }

        public Task<List<MovieInformationDto>> GetMovieInfoAsync(MovieBySearchDto result)
        {
            throw new NotImplementedException();
        }

        private T GetTestData<T>(string testfile)
        {
            var path = $"{basePath}{testfile}";
            string data = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<T>(data);
        }

        public Task<ToplistDto> DecreaseNumberOfLikes(string imdbID)
        {
            throw new NotImplementedException();
        }

        public Task<ToplistDto> IncreaseNumberOfLikes(string imdbID)
        {
            throw new NotImplementedException();
        }
    }
}