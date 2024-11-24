﻿using System.ComponentModel.DataAnnotations;

namespace CarsPlatform.Core.Entities
{
    public class Transmission
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string TransmissionType { get; set; } = null!;

        public ICollection<Car> Cars { get; set; } = new List<Car>();
    }
}
