using System.ComponentModel.DataAnnotations;

namespace RestaurantApi.Models
{
    public class CreateCocina
    {
        [Required (ErrorMessage = "El plato debe estar especificado")]
        public string Plato { get; set; }
        public string Descripcion { get; set; }
        public string Terminado { get; set; }
    }
}
