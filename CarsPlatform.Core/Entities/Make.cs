﻿using System.ComponentModel.DataAnnotations;

namespace CarsPlatform.Core.Entities
{
    public class Make
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string MakeName { get; set; } = null!;

        public ICollection<Car> Cars { get; set; } = new List<Car>();
    }
}