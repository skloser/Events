namespace Events.Model
{
    using System.ComponentModel.DataAnnotations;

    public class Address
    {
        [Key]
        public int AddressId { get; set; }

        [Required]
        [MinLength(2)]
        public string Name { get; set; }

        [Required]
        [MinLength(2)]
        public string City { get; set; }
    }
}