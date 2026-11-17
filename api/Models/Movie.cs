//the movie entity is one movie object is one row in the movies table
//it inherits Id, CreatedAt and UpdatedAt from Base Entity
namespace api.Models
{
    public class Movie : BaseEntity
    {
        //string.Empty gives a starting value, so the text is never null;
        public string Title { get; set; } = string.Empty;
        public string Director { get; set; } = string.Empty;
        public int ReleaseYear { get; set; }
        public int Rating { get; set; }
    }
}