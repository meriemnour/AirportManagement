using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServiceFlight1 : IServiceFlight1
    {
        //TP2-Q3: Créer la propriété Flights et l’initialiser à une liste vide
        public List<Flight> Flights { get; set; } = new List<Flight>();

        //TP2-Q6: Implémenter la méthode GetFlightDates(string destination)
        public IEnumerable<DateTime> GetFlightDates(string destination)
        {
            //List<DateTime> ls = new List<DateTime>();
            //for (int j = 0; j < Flights.Count; j++)
            //    if (Flights[j].Destination.Equals(destination))
            //        ls.Add(Flights[j].FlightDate);
            //return ls;


            ////TP2-Q7: Reformuler la requête avec foreach
            //List<DateTime> ls = new List<DateTime>();
            //foreach (Flight f in Flights)
            //    if (f.Destination.Equals(destination))
            //        ls.Add(f.FlightDate);
            //return ls;

            ////TP2-Q9: Reformuler la méthode en utilisant LINQ
            var req = from f in Flights
                      where f.Destination.Equals(destination)
                      select f.FlightDate;

            return req;


            ////TP2-Q19: Reformuler la méthode en utilisant Lambda Expression
            var reqLambda = Flights.Where(f => f.Destination.Equals(destination))
                .Select(f => f.FlightDate);

            return reqLambda.ToList();
        }

        //TP2-Q8: Implémenter la méthode GetFlights(string filterType, string filterValue)
        public void GetFlights(string filterType, string filterValue)
        {
            switch (filterType)
            {
                case "Destination":
                    foreach (Flight f in Flights)
                    {
                        if (f.Destination.Equals(filterValue))
                            Console.WriteLine(f);
                    }
                    break;
                case "FlightDate":
                    foreach (Flight f in Flights)
                    {
                        if (f.FlightDate == DateTime.Parse(filterValue))
                            Console.WriteLine(f);
                    }
                    break;
                case "EffectiveArrival":
                    foreach (Flight f in Flights)
                    {
                        if (f.EffectiveArrival == DateTime.Parse(filterValue))
                            Console.WriteLine(f);
                    }
                    break;
            }

            
        }
        public void ShowFlightDetails(Plane plane)
        {
            var req = from f in Flights
                      where f.Plane == plane
                      select new { f.FlightDate, f.Destination };
            // var reqLambda = Flights.Where(f => f.Plane == plane).Select(f => new { f.FlightDate, f.Destination });
            foreach (var v in req)
                Console.WriteLine("Flight Date; " + v.FlightDate + " Flight destination: " + v.Destination);
        }
        public int ProgrammedFlightNumber(DateTime startDate)
        {
            //var req = from f in Flights
            //          where (f.FlightDate - startDate).TotalDays > 0
            //          && (f.FlightDate - startDate).TotalDays < 7
            //          select f;
            //return req.Count();

            var reqLambda = Flights.Where(f => (f.FlightDate - startDate).TotalDays > 0
                      && (f.FlightDate - startDate).TotalDays < 7);
            return reqLambda.Count();
        }
        public double DurationAverage(string destination)
        {
            //return (from f in Flights
            //        where f.Destination.Equals(destination)
            //        select f.EstimatedDuration).Average();

            return Flights.Where(f=>f.Destination.Equals(destination))
                .Select(f=> f.EstimatedDuration).Average();
        }
        public IEnumerable<Flight> OrderedDurationFlights()
        {
            var req = from f in Flights 
                      orderby f.EstimatedDuration descending
                      select f;
            return req;

            //return Flights.OrderByDescending(f => f.EstimatedDuration);
        }

       /* public IEnumerable<Passenger> SeniorTravellers(Flight f)
        {
            //var query = from p in f.Passengers.OfType<Traveller>()
            //                    orderby p.BirthDate
            //                    select p;

            //return query.Take(3);

            return f.Passengers.OfType<Traveller>()
                .OrderBy(p => p.BirthDate)
                .Take(3);
        }*/

        public void DestinationGroupedFlights()
        {
            //var req = Flights.GroupBy(f => f.Destination);
            var req = from f in Flights
                      group f by f.Destination;

            foreach (var g in req)
            {
                Console.WriteLine("Destination: " + g.Key);
                foreach (var f in g)
                    Console.WriteLine("Décollage: " + f.FlightDate);
            }
           
        }

        //TP2-Q16: Les délégués
        public Action<Plane> FlightDetailsDel;
        public Func<string, double> DurationAverageDel;

        //TP2-Q17: Les méthodes anonymes
        public ServiceFlight1()
        {
            // DurationAverageDel = DurationAverage;
            DurationAverageDel = dest =>
            {
                return (from f in Flights
                        where f.Destination.Equals(dest)
                        select f.EstimatedDuration).Average();
            };
            //FlightDetailsDel = ShowFlightDetails;
            FlightDetailsDel = p =>
            {
                var req = from f in Flights
                          where f.Plane == p
                          select new { f.FlightDate, f.Destination };
                foreach (var v in req)
                    Console.WriteLine("Flight Date; " + v.FlightDate + " Flight destination: " + v.Destination);
            };
        }
    }
}