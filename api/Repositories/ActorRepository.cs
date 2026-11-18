using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Models;

namespace api.Repositories
{
    public class ActorRepository : IActorRepository
    {
        private readonly AppDbContext _db;
        public ActorRepository(AppDbContext db)
        {
            _db = db;
        }

        public List<Actor> GetAll()
        {
            return _db.Actors.ToList();
        }

        public Actor? GetById(int id)
        {
            return _db.Actors.Find(id);
        }
        public Actor Add(Actor actor)
        {
            _db.Actors.Add(actor);
            _db.SaveChanges();
            return actor;
        }

        public void Update(Actor actor)
        {
            _db.Actors.Update(actor);
            _db.SaveChanges();
        }

        public void Delete(Actor actor)
        {
            _db.Actors.Remove(actor);
            _db.SaveChanges();
        }
    }
}