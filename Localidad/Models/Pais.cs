using System.ComponentModel.DataAnnotations;

namespace Localidad.Models
{
    public class Pais : Base
    {
        
        [Required]
        public string Paises { get; set; }
        public int ProvinciaId{ get; set; }
        public Provincia Provincia { get; set; }
    }
}