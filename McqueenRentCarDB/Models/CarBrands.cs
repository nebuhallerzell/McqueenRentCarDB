using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace McqueenRentCarDB.Models
{
    public class CarBrands
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Please Add Brand Name")]
        [MaxLength(35)]
        [DisplayName("BRAND NAME")]

        public string? car_brand { get; set; }

    }
}
