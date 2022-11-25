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
    }
}
