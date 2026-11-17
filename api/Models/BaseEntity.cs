//the base entity columns Every table shares so we only have to write them once

namespace api.Models
{
    public class BaseEntity
    {
        //Ef Core treats a property named Id as the primary key 
        //The DB fills it in for us when a new row is saved / created
        public int Id { get; set; }
        //DateTime.UtcNow is the current in UTC, so every server agrees on the time
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}