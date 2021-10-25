using interaktiva14.Infrastructure;
using interaktiva14.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace interaktiva14.Repositories
{
    public class OmdbRepository //: IOmdbRepository
    {
        private readonly IApiClient apiClient;
        private readonly string basepoint = "http://www.omdbapi.com/?apikey=9428c299&";

        public OmdbRepository(IApiClient apiClient)
        {
            this.apiClient = apiClient;
        }
        //public async MovieBySearchDto GetMovieBySearch()
        //{
        //    var result = await apiClient.GetAsync<MovieBySearchDto>(basepoint);
        //    return result;
        //}
    }
}
