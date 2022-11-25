using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServicePlane : Service<Plane>, IServicePlane
    {
        //nfaskhouh
        /* private IUnitOfWork uow;
         //ctor + 2 tabulations
         public ServicePlane(IUnitOfWork unitOfWork)
         {
             this.uow = unitOfWork;
         }
         public void Add(Plane plane)
         {
             uow.Repository<Plane>().Add(plane);

         }

         public IEnumerable<Plane> GetAll()
         {
             return uow.Repository<Plane>().GetAll();

         }

         public void Remove(Plane plane)
         {
             uow.Repository<Plane>().Delete(plane);
         }*/
        public ServicePlane(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public void DeletePlanes()
        {
            Delete(p => (DateTime.Now - p.ManufactureDate).TotalDays > 3650);
        }

        public IEnumerable<Flight> GetFlights(int n)
        {

            return GetMany().OrderByDescending(p=>p.PlaneId).Take(n)
                                             .SelectMany(p=>p.Flights)
                                             .OrderBy (f=>f.FlightDate);

        }

        public IEnumerable<Passenger> GetPassenger(Plane p)
        {
             return   p.Flights.SelectMany(f => f.Tickets).Select(t=>t.Passenger);
        }

        public bool IsAvailablePlane(Flight f, int n)
        {
            
            return f.Plane.Capacity-f.Tickets.Count >= n;

        }
    }
}
