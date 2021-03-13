using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace api_barberia.Models
{
    [Table("Sucursal_Barbero")]
    public partial class SucursalBarbero
    {
        [Key]
        [Column("sucursal_barbero_id")]
        public int SucursalBarberoId { get; set; }
        [Column("sucursal_id")]
        public int? SucursalId { get; set; }
        [Column("barbero_id")]
        public int? BarberoId { get; set; }

        [ForeignKey(nameof(BarberoId))]
        [InverseProperty("SucursalBarberos")]
        public virtual Barbero Barbero { get; set; }
        [ForeignKey(nameof(SucursalId))]
        [InverseProperty("SucursalBarberos")]
        public virtual Sucursal Sucursal { get; set; }
    }
}
