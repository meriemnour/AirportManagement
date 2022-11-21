using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interfaces
{
    public interface IServiceFlight
    {
        IEnumerable<DateTime> GetFlightDates(string destination);
        void GetFlights(string filterType, string filterValue);
        void ShowFlightDetails(Plane plane);
        int ProgrammedFlightNumber(DateTime startDate);
        //IEnumerable<Passenger> SeniorTravellers(Flight f);
        IEnumerable<Flight> OrderedDurationFlights();
        double DurationAverage(string destination);
        void DestinationGroupedFlights();
    }
}
