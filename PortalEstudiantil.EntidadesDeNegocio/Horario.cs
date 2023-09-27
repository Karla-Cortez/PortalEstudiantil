using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Newtonsoft.Json;

namespace PortalEstudiantil.EntidadesDeNegocio
{
    public class Horario
    {
        [Key]
        public Int16 Id { get; set; }

        [ForeignKey("Grado")]
        [Required(ErrorMessage = "Grado es obligatorio")]
        public Int16 GradoId { get; set; }

        [ForeignKey("Materia")]
        [Required(ErrorMessage = "Materia es obligatoria")]
        public Int16 MateriaId { get; set; }

        [ForeignKey("Docente")]
        [Required(ErrorMessage = "El docente encargado es obligatorio")]
        public Int16 DocenteId { get; set; }

        [Required(ErrorMessage = "El dia es obligatorio")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string Dia { get; set; }

        [Required(ErrorMessage = "El Horario en que inicia es obligatorio")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string HorarioInicio { get; set; }

        [Required(ErrorMessage = "El horario en que termina es obligatorio")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string HorarioSalida { get; set; }

        [NotMapped]
        public int Top_Aux { get; set; }

        [ValidateNever]
        public Grado Grado { get; set; }

        [ValidateNever]
        public Materia Materia { get; set; }

        [ValidateNever]      
        public Docente Docente { get; set; }

       




    }
}
