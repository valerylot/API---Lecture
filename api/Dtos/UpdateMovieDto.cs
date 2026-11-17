//what the client sends to change a movie, the id comes in from the URL
namespace api.Dtos
{
    public class UpdateMovieDto
    {
        public string Title { get; set; } = string.Empty;
        public string Director { get; set; } = string.Empty;
        public int ReleaseYear { get; set; }
        public int Rating { get; set; }
    }
}