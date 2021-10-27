namespace interaktiva14.Models
{
    public class MovieResultDto
    {
        public string Title { get; set; }
        public string Plot { get; set; }
        public string imdbID { get; set; }
        public int numberOfLikes { get; set; }
        public int numberOfDislikes { get; set; }
    }
}