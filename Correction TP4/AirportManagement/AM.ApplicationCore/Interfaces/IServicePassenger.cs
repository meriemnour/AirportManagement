using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interfaces
{
    public interface IServicePassenger
    {
        public void Add(Passenger passenger);
        public void Remove(Passenger passenger);
        public IEnumerable<Passenger> GetAll();
    }
}
