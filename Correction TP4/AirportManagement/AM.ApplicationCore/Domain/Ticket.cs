using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    //porteuse de donnée
    public class Ticket
    {
        public double Prix { get; set; }
        public String Siege { get; set; }
        public bool VIP { get; set; }
        //[ForeignKey("PassengerFK")]
        // [ForeignKey("FlightFK")]
        public virtual Passenger Passenger { get; set; }
        [ForeignKey("Passenger")]
       
        //hya clé primaire mtaa passenger ama clé secondaire benesba lel ticket
        public string PassengerFK { get; set; }

        public virtual Flight Flight { get; set; }
        [ForeignKey("Flight")]

        public int FlightFK { get; set; }

    }
}
