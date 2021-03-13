using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace api_barberia.Models
{
    [Table("Barbero")]
    public partial class Barbero
    {
        public Barbero()
        {
            BarberoServicios = new HashSet<BarberoServicio>();
            SucursalBarberos = new HashSet<SucursalBarbero>();
            Turnos = new HashSet<Turno>();
        }

        [Key]
        [Column("barbero_id")]
        public int BarberoId { get; set; }
        [Required]
        [Column("nombre")]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required]
        [Column("apellido")]
        [StringLength(50)]
        public string Apellido { get; set; }

        [InverseProperty(nameof(BarberoServicio.Barbero))]
        public virtual ICollection<BarberoServicio> BarberoServicios { get; set; }
        [InverseProperty(nameof(SucursalBarbero.Barbero))]
        public virtual ICollection<SucursalBarbero> SucursalBarberos { get; set; }
        [InverseProperty(nameof(Turno.Barbero))]
        public virtual ICollection<Turno> Turnos { get; set; }
    }
}
