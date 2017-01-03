using System.Collections.Generic;
using secondapp.Models;

namespace secondapp.Data {
    public interface IGuitarRepository {
        IEnumerable<Guitar> All();
        Guitar Get(int id);
        void Update(Guitar entity);
    }
}