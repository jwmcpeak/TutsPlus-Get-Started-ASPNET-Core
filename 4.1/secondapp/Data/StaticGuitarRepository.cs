using System;
using System.Collections.Generic;
using System.Linq;
using secondapp.Models;

namespace secondapp.Data {
    public class StaticGuitarRepository : IGuitarRepository
    {
        private static readonly List<Guitar> _store = new List<Guitar>() {
             new Guitar() {Id = 1, Manufacturer = "Ibanez", Model = "Talman", Year = 1997 },
             new Guitar() {Id = 2, Manufacturer = "PRS", Model = "245", Year = 2013 },
             new Guitar() {Id = 3, Manufacturer = "Fender", Model = "Stratocaster", Year = 2012 },
        };

        public IEnumerable<Guitar> All()
        {
            return _store.ToArray();
        }

        public Guitar Get(int id)
        {
            return _store.SingleOrDefault(g => g.Id == id);
        }

        public void Update(Guitar entity)
        {
            throw new NotImplementedException();
        }
    }
}