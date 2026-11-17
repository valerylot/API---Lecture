//this is what the client sends to create a movie, no ID needed, the database makes that
namespace api.Dtos
{
    public class CreateMovieDto
    {
        public string Title { get; set; } = string.Empty;
        public string Director { get; set; } = string.Empty;
        public int ReleaseYear { get; set; }
        public int Rating { get; set; }
    }
}