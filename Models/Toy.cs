
using System.ComponentModel.DataAnnotations;
using ToysP.Models.Validation;

namespace ToysP.Models
{
    public class Toy
    {
        [Required]
        public int ToyId { get; set; }

        [Required]

        public string? Name { get; set; }

        //[Required]
       // public string? Color { get; set; }

        [Toy_EnsureCorrectSizing]
        public int? Age { get; set; }

        [Required]

        public string? Gender { get; set; }

        [Required]
        public double? Price { get; set; }

    }
}
