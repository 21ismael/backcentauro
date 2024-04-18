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
        public string? LicensePlate { get; set; }
        
        public int OfficeId { get; set; }
        [ForeignKey("OfficeId")]
        public Office? Office { get; set; }

        public int FleetId { get; set; }
        [ForeignKey("FleetId")]
        public Fleet? Fleet { get; set; }
    }
}

/*
INSERT INTO Cars (LicensePlate, OfficeId, FleetId)
VALUES 
    -- Coches en la oficina de Madrid (OfficeId = 1) y flota Toyota (FleetId = 1)
    ('123ABC', 1, 1),
    ('456DEF', 3, 2),

    -- Coches en la oficina de Lisboa (OfficeId = 6) y flota Honda (FleetId = 2)
    ('789GHI', 2, 3),
    ('987JKL', 5, 2),

    -- Coches en la oficina de Roma (OfficeId = 11) y flota Ford (FleetId = 3)
    ('321MNO', 9, 1),
    ('654PQR', 8, 3);
*/