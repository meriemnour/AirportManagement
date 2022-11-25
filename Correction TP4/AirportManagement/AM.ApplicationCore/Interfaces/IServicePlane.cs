using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interfaces
{
    public interface IServicePlane:IService<Plane>
    {
        public IEnumerable<Passenger> GetPassenger(Plane p);

        public IEnumerable<Flight> GetFlights(int n);
        public Boolean IsAvailablePlane(Flight f, int n);

        public void DeletePlanes();

    }
}
