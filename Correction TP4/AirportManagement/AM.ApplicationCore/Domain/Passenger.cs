using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        
       // public int Id { get; set; }
        [Key]
        [StringLength(7)]
        public string PassportNumber { get; set; }
        public FullName FullName { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date of birth")]
        public DateTime BirthDate { get; set; }
        [RegularExpression(@"^[0-9]{8}$", ErrorMessage = "Invalid Phone Number!")]
        public string TelNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        //prop de navigation

        //bech na7iwha khater wallet aana ticket ma aadech relation direct 
        //public ICollection<Flight> Flights { get; set; }
        //n3awdhouha b 
        public virtual ICollection<Ticket> Tickets { get; set; }

        //TP1-Q6: Réimplémenter la méthode ToString()
        public override string ToString()
        {
            return "FirstName: " + FullName.FirstName + " LastName: " + FullName.LastName + " date of Birth: "+ BirthDate;
        }

        //TP1-Q10: Créer les trois méthodes bool CheckProfile(...)
        //public bool CheckProfile(string firstName, string lastName)
        //{
        //    return FirstName == firstName && LastName == lastName;
        //}

        //public bool CheckProfile(string firstName, string lastName, string email)
        //{
        //    return FirstName == firstName && LastName == lastName && EmailAddress == email;
        //}

        public bool CheckProfile(string firstName, string lastName, string email = null)
        {
            if (email != null)
                return FullName.FirstName == firstName && FullName.LastName == lastName && EmailAddress == email;
            else
                return FullName.FirstName == firstName && FullName.LastName == lastName;
        }

        //TP1-Q11.a: Implémenter la méthode PassengerType()
        public virtual void PassengerType()
        {
            Console.WriteLine("I am a Passenger");
        }

    }
}
