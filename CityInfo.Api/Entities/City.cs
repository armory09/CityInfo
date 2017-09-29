using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CityInfo.Api.Entities
{
    public class City
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public int Name { get; set; }

        [MaxLength(200)]
        public int Description { get; set; }
        public ICollection<PointOfInterest> PointsOfInterest { get; set; }
        = new List<PointOfInterest>();
    }
}
