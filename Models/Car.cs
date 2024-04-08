using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebAPI.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public string? LicensePlate { get; set; }

        public int OfficeId { get; set; }

        [ForeignKey("OfficeId")]
        public Office? Office { get; set; }
    }
}

/*
INSERT INTO Cars (Brand, Model, LicensePlate, OfficeId) VALUES 
    ('Toyota', 'Corolla', 'ABC123', 1),
    ('Ford', 'Mustang', 'XYZ789', 2),
    ('Honda', 'Civic', 'DEF456', 1),
    ('Chevrolet', 'Camaro', 'GHI789', 4),
    ('Volkswagen', 'Golf', 'JKL012', 5),
    ('Audi', 'A4', 'MNO345', 3),
    ('BMW', '3 Series', 'PQR678', 1),
    ('Mercedes-Benz', 'C-Class', 'STU901', 3),
    ('Lexus', 'ES', 'VWX234', 2),
    ('Hyundai', 'Elantra', 'YZA567', 1);
*/