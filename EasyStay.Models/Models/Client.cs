using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyStay.Models.Models
{
    public class Client: BaseModel
    {
        public string? FirtsName { get; set; }
        public string? SecondName { get; set; }
        public string? LastName { get; set; }
        public string? SecondLastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public string? TypeDocument { get; set; }
        public string? NumberDocument { get; set; }
        public string? Email { get; set;}
        public string? Phone { get; set;}

        public ICollection<Reservation>? Reservations { get; set; }
    }
}
