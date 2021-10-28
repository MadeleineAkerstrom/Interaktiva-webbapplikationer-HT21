using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static interaktiva14.Models.MovieBySearchDto;

namespace interaktiva14.Models.ViewModels
{
    public class HomeViewModel
    {
        // Movie club information from CMDb
        public List<ToplistDto> Toplist {get; set;}
        public string imdbID { get; set; }
        public int numberOfLikes { get; set; }
        public int numberOfDislikes { get; set; }

        public List<MovieResultDto> Movies { get; set; }

        public HomeViewModel(List<MovieResultDto> searchResult)
        {
            Movies = searchResult;
        }
        public HomeViewModel()
        {
            
        }
    }
}
