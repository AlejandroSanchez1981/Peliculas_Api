using Peliculas_Api.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace Peliculas_Api.Entidades
{
    public class Genero
    {

        public int Id { get; set; }

        [Required]
        public required string Nombre { get; set; }

    }
}





//[MinLength(1, ErrorMessage = "El campo {0} es requerido" )]
//[StringLength(2, ErrorMessage ="El campo {0} debe tener {1} caracteres o menos")]
//[PrimeraLetraMayuscula]