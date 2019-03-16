using System;
using System.Collections.Generic;
using System.Text;

namespace MuscordBot.Domain {
    public interface IMuseumRepo {
        IEnumerable<Museum> getAll();
        Museum getByName(string name);
        void add(Museum ms);
        void remove(Museum ms);
        void SaveChanges();
    }
}
