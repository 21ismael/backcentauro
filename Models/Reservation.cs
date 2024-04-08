using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }

        public int CarId { get; set; }
        [JsonIgnore]
        public Car? Car { get; set; }

        public int UserId { get; set; }
        [JsonIgnore]
        public User? User { get; set; }

        public int OfficeId { get; set; }
       
        [JsonIgnore]
        public Office? Office { get; set; }
        
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}

/*
INSERT INTO Reservations (CarId, UserId, OfficeId, StartDate, EndDate) 
VALUES 
    (4, 1, 1, '2024-04-10 09:00:00', '2024-04-15 17:00:00');
*/