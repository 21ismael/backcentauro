using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? IdentityNumber { get; set; }
    }

    /*INSERT INTO Users (Name, LastName, IdentityNumber) VALUES
    ('Juan', 'Perez', '12345678A'),
    ('Maria', 'Gomez', '87654321B'),
    ('Carlos', 'Lopez', '98765432C'),
    ('Ana', 'Martinez', '54321678D'),
    ('Pedro', 'Sanchez', '87654321E');*/
}