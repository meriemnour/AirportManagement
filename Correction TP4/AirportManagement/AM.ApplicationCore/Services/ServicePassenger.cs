using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServicePassenger : IServicePassenger
    {
        private IUnitOfWork uow;
        public ServicePassenger(IUnitOfWork unitOfWork)
        {
            uow = unitOfWork;
        }
        public void Add(Passenger passenger)
        {
            uow.Repository<Passenger>().Add(passenger);

        }

        public IEnumerable<Passenger> GetAll()
        {
            return uow.Repository<Passenger>().GetAll();
        }

        public void Remove(Passenger passenger)
        {
            uow.Repository<Passenger>().Delete(passenger);

        }
    }
}
