using System.ComponentModel.DataAnnotations;

namespace Localidad.Models
{
    public class Provincia : Base
    {
       
        [Required]
        public string Provincias { get; set; }
        public int DeptoId{ get; set; }
        public Depto Depto { get; set; }
    }
}