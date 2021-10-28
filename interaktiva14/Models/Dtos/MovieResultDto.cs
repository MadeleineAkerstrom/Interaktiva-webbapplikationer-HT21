using System.Collections.Generic;

namespace interaktiva14.Models
{
    public class MovieResultDto
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string Actors { get; set; }
        public string Plot { get; set; }
        public string Awards { get; set; }
        public List<RatingsDto> Ratings { get; set; }
        public string Metascore { get; set; }
        public string imdbVotes { get; set; }
        public string imdbID { get; set; }
        public string Poster { get; set; }

        public int numberOfLikes { get; set; }
        public int numberOfDislikes { get; set; }
    }
}