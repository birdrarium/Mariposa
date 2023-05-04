using System;
using System.ComponentModel.DataAnnotations;

namespace MariposaAPI.Models
{
    public class ButterflyAPIModel 
    {
        public int Id { get; set; }
        [Required]
        public string LatinName { get; set; }
        public string PolishName { get; set; }
        public string Description { get; set; }

        public ButterflyAPIModel(int id, string latinName, string polishName, string description)
        {
            Id = id;
            LatinName = latinName;
            PolishName = polishName;
            Description = description;
        }
    }
}
