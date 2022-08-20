using System.ComponentModel.DataAnnotations;

namespace Localidad.Models
{
    public class Depto : Base
    {
        
        [Required]
        public string Departamentos { get; set; }
    }
}