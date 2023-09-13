using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalEstudiantil.EntidadesDeNegocio
{
    public class Estudiante
    {
        [Key]
        public Int16 Id { get; set; }

        [Required(ErrorMessage = "Nombre es obligatorio")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Apellido es obligatorio")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El código de estudiante es obligatorio")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string CodigoEstudiante { get; set; }

        [ForeignKey("Grado")]
        [Required(ErrorMessage = "El grado es obligatorio")]
        [Display(Name = "Grado")]
        public Int16 GradoId { get; set; }

        [ForeignKey("Turno")]
        [Required(ErrorMessage = "El turno es obligatorio")]
        [Display(Name = "Turno")]
        public Int16 TurnoId { get; set; }

        [Required(ErrorMessage = "El encargado del estudiante es obligatorio")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string Encargado { get; set; }

        [Required(ErrorMessage = "El DUI del encargado del estudiante es obligatorio")]
        [Display(Name = "EncargadoDUI")]
        public Int32 EncargadoDUI { get; set; }

        [Required(ErrorMessage = "El correo es obligatorio")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "La dirección del estudiante es obligatorio")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El número de teléfono es obligatorio")]
        [Display(Name = "Telefono")]
        public Int32 Telefono { get; set; }

        [NotMapped]

        public int Top_Aux { get; set; }
        public Grado Grado { get; set; }

        public Turno Turno { get; set; }

        

        

    }


    public enum Estatus_Estudiante
    {
        ACTIVO = 1,
        INACTIVO = 2
    }


}