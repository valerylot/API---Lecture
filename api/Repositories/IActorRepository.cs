using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Repositories
{
    public interface IActorRepository
    {
        Task<List<Actor>> GetAllAsync();
        Task<Actor?> GetByIdAsync(int id);
        Task<Actor> AddAsync (Actor actor);
        Task UpdateAsync (Actor actor);
        Task DeleteAsync (Actor actor);
    }
}