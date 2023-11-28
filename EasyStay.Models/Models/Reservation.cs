using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyStay.Models.Models
{
    public class Reservation: BaseModel
    {
        public Guid? RoomId { get; set; }
        public Guid? ClientId { get; set; }
        public string? TypeRoom { get; set; }
        public string? RoomNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? City { get; set; }
        public int NumberOfPersons { get; set; }
        public string? EmergencyContactName { get; set; }
        public string? EmergencyContactPhoneNumber { get; set; }

        public Room? Room { get; set; }
        public Client? Client { get; set; }
    }
}
