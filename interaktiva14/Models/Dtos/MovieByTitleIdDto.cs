using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace interaktiva14.Models
{
    public partial class MovieByTitleIdDto
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string Released { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string Actors { get; set; }
        public string Plot { get; set; }
        public string Awards { get; set; }
        public string Poster { get; set; }
        public List<RatingsDto> Ratings { get; set; }
        public string Metascore { get; set; }
        public string imdbVotes { get; set; }
        public string imdbID { get; set; }
    }
}