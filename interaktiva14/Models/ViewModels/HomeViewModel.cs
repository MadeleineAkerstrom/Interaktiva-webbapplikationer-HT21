using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static interaktiva14.Models.MovieBySearchDto;

namespace interaktiva14.Models.ViewModels
{
    public class HomeViewModel
    {
        public List<MovieDto> Search { get; set; }
        public string totalResults { get; set; }
        public string Response { get; set; }
    }
}
