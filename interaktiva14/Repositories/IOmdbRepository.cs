using interaktiva14.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace interaktiva14.Repositories
{
    public interface IOmdbRepository
    {
        Task<MovieInformationDto> GetMovieByIdAsync(string movieName);

        /// <summary>
        /// Retrieves searchresult of movies
        /// </summary>
        /// <returns>MovieBySearchDto</returns>
        Task<MovieBySearchDto> GetMovieBySearchAsync(string movieName);
        Task<MovieInformationDto> GetMovieByTitleAsync(string movieName);
        Task<List<MovieInformationDto>> GetMovieInfoAsync(MovieBySearchDto result);
    }
}
