using Microsoft.EntityFrameworkCore;
using MuscordBot.Domain;
using System.Collections.Generic;
using System.Linq;

namespace MuscordBot.Data.Repositories {
    class MuseumRepository : IMuseumRepo {
        private DbSet<Museum> _musea;
        private DbContext _context;

        public MuseumRepository(ApplicationDbContext context) {
            _context = context;
            _musea = context.Musea;
        }

        public void add(Museum ms) {
            _musea.Add(ms);
        }

        public IEnumerable<Museum> getAll() {
            return _musea.ToList();
        }

        public Museum getByName(string name) {
            return _musea.Include(m=>m.Accesability)
                .FirstOrDefault(m => m.Naam.ToLower().Contains(name.ToLower()));
        }

        public void remove(Museum ms) {
            _musea.Remove(ms);
        }

        public void SaveChanges() {
            _context.SaveChanges();
        }
    }
}
