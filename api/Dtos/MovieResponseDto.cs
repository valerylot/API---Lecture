//DTOs are JSON shapes that the client sees. The movie entity stays inside the API


//No CreatedAt or UpdatedAt: the client only gets the fields we choose to share 
namespace api.Dtos
{
    public class MovieResponseDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Director { get; set; } = string.Empty;
        public int ReleaseYear { get; set; }
        public int Rating { get; set; }
    }
}