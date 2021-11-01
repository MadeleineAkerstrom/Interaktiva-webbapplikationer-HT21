namespace interaktiva14.Models
{
    public class MovieDto
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string imdbID { get; set; }
        public string Type { get; set; }
        public string Poster { get; set; }
        public string Plot { get; set; }
        public string Actors { get; set; }
        public int NumberOfLikes { get; set; }
        public int NumberOfDislikes { get; set; }
    }
}
