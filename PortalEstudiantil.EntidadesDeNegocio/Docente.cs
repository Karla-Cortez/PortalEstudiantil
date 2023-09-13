using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PortalEstudiantil.EntidadesDeNegocio
{
    public class Docente
    {
        [Key]
        public Int16 Id { get; set; }

        [Required(ErrorMessage = "Nombre es obligatorio")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Apellido es obligatorio")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string Apellido { get; set; }



        [Required(ErrorMessage = "El código de docente es obligatorio")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string CodigoDocente { get; set; }

        [Required(ErrorMessage = "La clave es obligatoria")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string Clave { get; set; }

        [ForeignKey("Rol")]
        [Required(ErrorMessage = "El Rol es requerido")]
        [Display(Name = "Rol")]
        public Int16 RolId { get; set; }

        [ForeignKey("Materia")]
        [Required(ErrorMessage = "La materia es obligatoria")]
        [Display(Name = "Materia")]
        public Int16 MateriaId { get; set; }

        [ForeignKey("Ciclo")]
        [Required(ErrorMessage = "El ciclo encargado es obligatorio")]
        [Display(Name = "Ciclo")]
        public Int16 CicloId { get; set; }

        [ForeignKey("Turno")]
        [Required(ErrorMessage = "El turno es obligatorio")]
        [Display(Name = "Turno")]
        public Int16 TurnoId { get; set; }

        [Required(ErrorMessage = "El DUI es obligatorio")]
        [Display(Name = "Dui")]
        public Int32 DUI { get; set; }

        [Required(ErrorMessage = "El correo es obligatorio")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "La dirección es obligatorio")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string Dirección { get; set; }

        [Required(ErrorMessage = "El número de teléfono es obligatorio")]
        [Display(Name = "Telefono")]
        public Int32 Telefono { get; set; }


        public Rol Rol { get; set; }
        public Materia Materia { get; set; }
        public Ciclo Ciclo { get; set; }
        public Turno Turno { get; set; }

        [NotMapped]
        public int Top_Aux { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Confirmar el password")]
        [StringLength(32, ErrorMessage = "Password debe estar entre 5 a 32 caracteres", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password y confirmar password deben de ser iguales")]
        [Display(Name = "Confirmar password")]
        public string ConfirmPassword_aux { get; set; }
    }
}
