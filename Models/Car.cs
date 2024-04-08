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

        public double? DailyRate { get; set; }
    }
}

/*
INSERT INTO Cars (Brand, Model, LicensePlate, OfficeId, DailyRate) VALUES 
    ('Toyota', 'Corolla', 'ABC123', 1, 40),
    ('Ford', 'Mustang', 'XYZ789', 2, 50),
    ('Honda', 'Civic', 'DEF456', 1, 39.99),
    ('Chevrolet', 'Camaro', 'GHI789', 4, 70),
    ('Volkswagen', 'Golf', 'JKL012', 5, 55),
    ('Audi', 'A4', 'MNO345', 3, 59.99),
    ('BMW', '3 Series', 'PQR678', 1, 59.99),
    ('Mercedes-Benz', 'C-Class', 'STU901', 3, 60),
    ('Lexus', 'ES', 'VWX234', 2, 69.99),
    ('Hyundai', 'Elantra', 'YZA567', 1, 49.99);
*/