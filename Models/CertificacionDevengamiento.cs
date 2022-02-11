﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("certificacion_devengamiento")]
    public class CertificacionDevengamiento : EntidadBase
    {
        [Key]
        [Column("id_certificacion")]
        public int Id { get; set; }

        [Required]
        [Column("fecha")]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        [Required]
        [Column("devengamiento_certificado")]
        public double HorasCertificadas { get; set; }

        [Required]
        [Column("fecha_certificacion")]
        [DataType(DataType.Date)]
        public DateTime FechaCertificacion { get; set; }

        [Required]
        [Column("legajo")]
        public int Legajo { get; set; }

        [Required]
        [Column("fecha_modificacion")]
        [DataType(DataType.Date)]
        public DateTime FechaModificacion { get; set; }

        [Required]
        [Column("mes")]
        public int Mes { get; set; }

        [Required]
        [Column("anio")]
        public int Anio { get; set; }

        //Relaciones
        [Required]
        [Column("id_proyecto")]
        [StringLength(70)]
        public string IdProyecto { get; set; }

        [Required]
        [ForeignKey("IdProyecto")]
        public Proyecto Proyecto { get; set; }

        [Required]
        [Column("id_usuario")]
        public int IdUsuario { get; set; }

        [Required]
        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }
    }
}
