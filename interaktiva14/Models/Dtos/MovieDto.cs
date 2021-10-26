namespace interaktiva14.Models
{
    public partial class MovieBySearchDto
    {
        public class MovieDto
        {
            public string Title { get; set; }
            public string Year { get; set; }
            public string imdbID { get; set; }
            public string Type { get; set; }
            public string Poster { get; set; }
        }
    }
}
