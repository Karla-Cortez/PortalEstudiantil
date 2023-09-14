using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace PortalEstudiantil.EntidadesDeNegocio
{
    public class Grado
    {
        [Key]
        public Int16 Id { get; set; }

        [Required(ErrorMessage = " Nombre es obligatorio")]
        [StringLength(50, ErrorMessage = "máximo 50 caracteres")]

        public string Nombre { get; set; }

        [NotMapped]
        public int Top_Aux { get; set; }

        //public List<Docente> docente { get; set; }
        [ValidateNever]
        public List<Estudiante> estudiante { get; set; }
        [ValidateNever]
        public List<Horario> horario { get; set; }

    }
}
