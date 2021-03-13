using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace api_barberia.Models
{
    [Table("Servicio")]
    public partial class Servicio
    {
        public Servicio()
        {
            BarberoServicios = new HashSet<BarberoServicio>();
            SucursalServicios = new HashSet<SucursalServicio>();
            Turnos = new HashSet<Turno>();
        }

        [Key]
        [Column("servicio_id")]
        public int ServicioId { get; set; }
        [Required]
        [Column("nombre")]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required]
        [Column("descripcion")]
        [StringLength(500)]
        public string Descripcion { get; set; }
        [Column("duracion")]
        public int? Duracion { get; set; }

        [InverseProperty(nameof(BarberoServicio.Servicio))]
        public virtual ICollection<BarberoServicio> BarberoServicios { get; set; }
        [InverseProperty(nameof(SucursalServicio.Servicio))]
        public virtual ICollection<SucursalServicio> SucursalServicios { get; set; }
        [InverseProperty(nameof(Turno.Servicio))]
        public virtual ICollection<Turno> Turnos { get; set; }
    }
}
