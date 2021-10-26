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
        public List<MovieDto> Search { get; set; }
        [DisplayFormat(DataFormatString ="st")]
        public string totalResults { get; set; }
        public string Response { get; set; }
         public string imdbID { get; set; }
        public int numberOfLikes { get; set; }
        public int numberOfDislikes { get; set; }
    }
}
