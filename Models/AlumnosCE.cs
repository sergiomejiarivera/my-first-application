using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD_Alumnos.Models
{
    public class AlumnosCE
    {
        
        public int Id { get; set; }
        [Required]
        [Display(Name = "Ingrese Nombres")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Ingrese Apellidos")]
        public string Apellido { get; set; }

        [Required]
        [Display(Name = "Edad del Alumno")]
        public int Edad { get; set; }

        [Required]
        [Display(Name = "Sexo del Alumno")]
        public string Sexo { get; set; }

          
        [Required]
        [Display(Name = "Ciudad")]
        public int CodCiudad { get; set; }
    }
    [MetadataType(typeof(AlumnosCE))]

    public partial class alumno
    {

        public string NombreCompleto { get { return Nombre +" "+ Apellido; } }
    }

}