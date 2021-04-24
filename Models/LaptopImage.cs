using System.ComponentModel.DataAnnotations;

namespace testCore.Models
{
    public class LaptopImage
    {
        [Key]
        public int Id { get; set; }
        public int LaptopId {get;set;}
        public string ImagePath {get;set;}
        public Laptop Laptop { get; set; }

    }
}