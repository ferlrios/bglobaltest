using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BGlobal.Models
{
    public class Vehicle
    {
        [Key]
        [Required(ErrorMessage = "Este campo es requerido")]
        [StringLength(8,MinimumLength =8, ErrorMessage ="La patente debe tener una longitud de 8 caracteres.")]
        public string Patente { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [Range(1,10, ErrorMessage = "La cantidad de puertas debe ser entre 1 y 10")]
        public int Puertas { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public string Dueño { get; set; }
    }
}
