using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDNetCore.Models
{
    public class Libro
    {
        [Key]
        public int Id { get; set; }
        [Required (ErrorMessage ="Este campo es obligatorio")]
        [StringLength(50,ErrorMessage ="el {0} debe ser almenos {2} y maximo {1} caracteres", MinimumLength =3)]//lengt cantidad de caracteres
        [Display(Name ="Titulo")]//este display es una marca de agua en el cuadro de texto
        public String Titulo { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(50, ErrorMessage = "el {0} debe ser almenos {2} y maximo {1} caracteres", MinimumLength = 3)]//lengt cantidad de caracteres
        [Display(Name = "Descripcion")]

        public string Descripcion { get; set; }


        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DataType (DataType.Date)]//esto es para que traiga solo la fecha.
        [Display(Name = "Fecha Lanzamiento")]

        public DateTime FechaLanzamiento { get; set; }

        public string Autor { get; set; }

        public int Precio { get; set; }
    }
}
