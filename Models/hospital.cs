using System.ComponentModel.DataAnnotations;

namespace HospitalService.Models
{
    // For the ORM to work properly these properties should match exactly to the Database entities
    public class hospital
    {
        [Key]
        public int Id { get; set; }

        public string Zip { get; set; }
        public string City { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public int Beds { get; set; }
        public string County { get; set; }
    }
}
