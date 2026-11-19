using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class ActorRepository : IActorRepository
    {
        private readonly AppDbContext _db;
        public ActorRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<Actor>> GetAllAsync()
        {
            return await _db.Actors.ToListAsync();
        }

        public async Task<Actor?> GetByIdAsync(int id)
        {
            return await _db.Actors.FindAsync(id);
        }
        public async Task<Actor> AddAsync(Actor actor)
        {
            _db.Actors.Add(actor);
           await _db.SaveChangesAsync();
            return actor;
        }

        public async Task UpdateAsync(Actor actor)
        {
            _db.Actors.Update(actor);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Actor actor)
        {
            _db.Actors.Remove(actor);
            await _db.SaveChangesAsync();
        }
    }
}