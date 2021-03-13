using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace api_barberia.Models
{
    [Table("Barbero_Servicio")]
    public partial class BarberoServicio
    {
        [Key]
        [Column("barbero_servicio_id")]
        public int BarberoServicioId { get; set; }
        [Column("barbero_id")]
        public int? BarberoId { get; set; }
        [Column("servicio_id")]
        public int? ServicioId { get; set; }

        [ForeignKey(nameof(BarberoId))]
        [InverseProperty("BarberoServicios")]
        public virtual Barbero Barbero { get; set; }
        [ForeignKey(nameof(ServicioId))]
        [InverseProperty("BarberoServicios")]
        public virtual Servicio Servicio { get; set; }
    }
}
