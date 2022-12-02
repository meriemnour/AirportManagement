using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public enum PlaneType
    {
        Boing,
        Airbus
    }
    public class Plane
    {
        public int PlaneId { get; set; }
        public PlaneType PlaneType { get; set; }

        [NotMapped]
        public string Information { get { return PlaneId + " " + ManufactureDate + " " + Capacity; } }
        public DateTime ManufactureDate { get; set; }
        [Range(0, int.MaxValue)]
        public int Capacity { get; set; }
        //prop de navigation
        public virtual ICollection<Flight> Flights { get; set; }

        //TP1-Q6: Réimplémenter la méthode ToString()
        public override string ToString()
        {
            return "PlaneType: " + PlaneType + " ManufactureDate: " + ManufactureDate + " Capacity: " + Capacity;
        }
        //TP1-Q7: Constructure non paramétré
        public Plane()
        {

        }
        //TP1-Q8: Constructure paramétré
        public Plane(PlaneType pt, int capacity, DateTime date)
        {
            PlaneType = pt;
            Capacity = capacity;
            ManufactureDate = date;
        }
    }
}
