using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FooApi.Entities
{
    [Table("OtherThing", Schema = "dbo")]
    public class OtherThing
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int ThingID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
