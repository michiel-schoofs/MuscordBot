using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MuscordBot.Domain {
    public class Accesability {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public bool wheelchairAc { get; set; }
        public int aangepasteToilleten { get; set; }
        public int aangepasteParking { get; set; }
        public int liften { get; set; }
    }
}
