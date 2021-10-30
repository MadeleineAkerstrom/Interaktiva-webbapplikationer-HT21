using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static interaktiva14.Models.MovieBySearchDto;

namespace interaktiva14.Models.ViewModels
{
    public class SearchResultViewModel
    {
        public List<MovieResultDto> Movies { get; set; }
        public string imdbID { get; set; }

        public SearchResultViewModel(List<MovieResultDto> movieList)
        {
            Movies = movieList;
        }
        public SearchResultViewModel()
        {
            
        }
    }
}
