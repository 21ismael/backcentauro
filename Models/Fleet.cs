using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebAPI.Models
{
    public class Fleet
    {
        public int Id { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public string? Image { get; set; }
        public double? DailyRate { get; set; }
        
        [JsonIgnore]
        public List<Car> Cars { get; set; } = new List<Car>();
    }
}

/*
INSERT INTO Fleet (Brand, Model, Image, DailyRate)
VALUES ('Toyota', 'Corolla', 'url_imagen_corolla.jpg', 60.0),
       ('Honda', 'Civic', 'url_imagen_civic.jpg', 55.0),
       ('Ford', 'Focus', 'url_imagen_focus.jpg', 50.0);

*/