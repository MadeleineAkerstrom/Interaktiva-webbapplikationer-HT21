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
        // Movie search
        public List<MovieDto> Search { get;}
        [DisplayFormat(DataFormatString ="st")]
        public string totalResults { get;}
        public string Response { get;}

        // Movie club information from CMDb
         public string imdbID { get; set; }
        public int numberOfLikes { get; set; }
        public int numberOfDislikes { get; set; }

        // Movie information
        public string Title { get; }
        public string Year { get; }
        public string Actors { get; }
        public string Plot { get; }
        public string Awards { get; }
        public List<RatingsDto> Ratings { get; }
        public string Metascore { get; }
        public string imdbVotes { get; }

        public HomeViewModel(MovieBySearchDto MovieBySearch, MovieByTitleIdDto movieByTitleId)
        {
            // Movie Search
            Search = MovieBySearch.Search;
            totalResults = MovieBySearch.totalResults;
            Response = MovieBySearch.Response; 
            
            //Movie information
            Plot = movieByTitleId.Plot;
            Title = movieByTitleId.Title;
            // etc... 
        }

        public HomeViewModel()
        {
            
        }
    }
}
