using System;

namespace MariposaAPI.Models
{
    public class ButterflyModel
    {
        public int Id { get; set; }
        public string LatinName { get; set; }
        public string PolishName { get; set; }
        public string Description { get; set; }

        public ButterflyModel(int id, string latinName, string polishName, string description)
        {
            Id = id;
            LatinName = latinName;
            PolishName = polishName;
            Description = description;
        }
    }
}
