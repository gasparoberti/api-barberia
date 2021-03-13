using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace api_barberia.Models
{
    [Table("Sucursal")]
    public partial class Sucursal
    {
        public Sucursal()
        {
            SucursalBarberos = new HashSet<SucursalBarbero>();
            SucursalServicios = new HashSet<SucursalServicio>();
            Turnos = new HashSet<Turno>();
        }

        [Key]
        [Column("sucursal_id")]
        public int SucursalId { get; set; }
        [Column("hora_apertura")]
        public TimeSpan HoraApertura { get; set; }
        [Column("hora_cierre")]
        public TimeSpan HoraCierre { get; set; }
        [Required]
        [Column("direccion")]
        [StringLength(50)]
        public string Direccion { get; set; }

        [InverseProperty(nameof(SucursalBarbero.Sucursal))]
        public virtual ICollection<SucursalBarbero> SucursalBarberos { get; set; }
        [InverseProperty(nameof(SucursalServicio.Sucursal))]
        public virtual ICollection<SucursalServicio> SucursalServicios { get; set; }
        [InverseProperty(nameof(Turno.Sucursal))]
        public virtual ICollection<Turno> Turnos { get; set; }
    }
}
