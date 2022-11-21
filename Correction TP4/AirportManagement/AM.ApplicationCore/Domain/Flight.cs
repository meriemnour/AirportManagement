using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Flight
    {
        //public string Airline { get; set; }
        public int FlightId { get; set; }
        public DateTime FlightDate { get; set; }
        public int EstimatedDuration { get; set; }
        public DateTime EffectiveArrival { get; set; }
        //? definition d'un champs optionnel
        public string? Departure { get; set; }
        public string Destination { get; set; }
        //prop de navigation
        public virtual ICollection<Passenger> Passengers { get; set; }
        //[ForeignKey("PlaneFK")]
        public virtual Plane Plane { get; set; }
        [ForeignKey("Plane")]
        public  int PlaneFK{ get; set; }
        //TP1-Q6: Réimplémenter la méthode ToString()
        public override string ToString()
        {
            return "FlightId: " + FlightId + " FlightDate: " + FlightDate + " Destination: " + Destination;
        }
    }
}
