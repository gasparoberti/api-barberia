using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace api_barberia.Models
{
    [Table("Turno")]
    public partial class Turno
    {
        [Key]
        [Column("turno_id")]
        public int TurnoId { get; set; }
        [Required]
        [Column("nombre")]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required]
        [Column("apellido")]
        [StringLength(50)]
        public string Apellido { get; set; }
        [Column("reservado")]
        public bool Reservado { get; set; }
        [Column("sucursal_id")]
        public int? SucursalId { get; set; }
        [Column("servicio_id")]
        public int? ServicioId { get; set; }
        [Column("barbero_id")]
        public int? BarberoId { get; set; }
        [Column("fecha", TypeName = "datetime")]
        public DateTime Fecha { get; set; }

        [ForeignKey(nameof(BarberoId))]
        [InverseProperty("Turnos")]
        public virtual Barbero Barbero { get; set; }
        [ForeignKey(nameof(ServicioId))]
        [InverseProperty("Turnos")]
        public virtual Servicio Servicio { get; set; }
        [ForeignKey(nameof(SucursalId))]
        [InverseProperty("Turnos")]
        public virtual Sucursal Sucursal { get; set; }
    }
}
