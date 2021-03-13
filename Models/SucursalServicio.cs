using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace api_barberia.Models
{
    [Table("Sucursal_Servicio")]
    public partial class SucursalServicio
    {
        [Key]
        [Column("sucursal_servicio_id")]
        public int SucursalServicioId { get; set; }
        [Column("sucursal_id")]
        public int? SucursalId { get; set; }
        [Column("servicio_id")]
        public int? ServicioId { get; set; }

        [ForeignKey(nameof(ServicioId))]
        [InverseProperty("SucursalServicios")]
        public virtual Servicio Servicio { get; set; }
        [ForeignKey(nameof(SucursalId))]
        [InverseProperty("SucursalServicios")]
        public virtual Sucursal Sucursal { get; set; }
    }
}
