using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PortalEstudiantil.EntidadesDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalEstudiantil.AccesoADatos
{
    public class BDContexto : DbContext 
    {
        public DbSet<Ciclo> Ciclo {  get; set; }
        public DbSet<Docente> Docente { get; set; }
        public DbSet<Estudiante> Estudiante { get; set; }
        public DbSet<Grado> Grado { get; set; }
        public DbSet<Horario> Horario { get; set; }
        public DbSet<Materia> Materia { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Turno> Turno { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Jonathan
            optionsBuilder.UseSqlServer(@"Data Source=JONATHAN;Initial Catalog=PortalEstudiantilDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            //Frank
            //optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-46UEJO3;Initial Catalog=PortalEstudiantilDB;Integrated Security=True");
            //Maura

            //Karla
            //optionsBuilder.UseSqlServer(@"Data Source=NESS;Initial Catalog=PortalEstudiantilDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
    }
}
