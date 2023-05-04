using System;
namespace WebApp.Models
{
    public class ButterflyViewModel
    {

        public int Id { get; set; }
        public string? PolishName { get; set; }
        public string LatinName { get; set; }
        public string Description { get; set; }

        public ButterflyViewModel()
        {
        }
    }
}
