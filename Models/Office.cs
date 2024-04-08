using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;


namespace WebAPI.Models
{
    public class Office
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Country { get; set; }

        [JsonIgnore]
        public List<Car> Cars { get; set; } = new List<Car>(); 
    }

    /*
    INSERT INTO Offices (Name, Country) VALUES 
    ('Barcelona Airport', 'España'),
    ('Lisboa', 'Portugal'),
    ('Roma', 'Italia'),
    ('Atenas Airport', 'Grecia'),
    ('Madrid', 'España');
    */
}