﻿using System.ComponentModel.DataAnnotations;

namespace WebUygulamaProje1.Models
{
    public class Kitap
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string KitapAdi { get; set; }

        public string Tanim { get; set;}
        
        [Required]
        public string Yazar { get; set; }

        [Required]
        [Range(0, 5000)]
        public Double Fiyat { get; set; }

    }
}