using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("proyectos")]
    public class Proyecto
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("id_proyecto")]
        [StringLength(70)]
        public string? Id { get; set; }
        
        [Column("cliente")]
        [StringLength(120)]
        public string? Cliente { get; set; }

        [Column("nombre")]
        [StringLength(120)]
        public string? Nombre { get; set; }

        [Column("pm")]
        [StringLength(70)]
        public string? Pm { get; set; }

        [Column("tipo")]
        [StringLength(45)]
        public string? Tipo { get; set; }

        [Column("sbu")]
        [StringLength(45)]
        public string? Sbu { get; set; }

        [Column("estado")]
        [StringLength(45)]
        public string? Estado { get; set; }

        [Column("mailPM")]
        [StringLength(45)]
        public string? MailPM { get; set; }

        [Column("horas_certificadas")]        
        public int HorasCertificadas { get; set; }

        [Column("devengamiento_certificado")]
        public double DevengamientoCertificado { get; set; }

        [Column("horas_planificadas")]
        public int HorasPlanificadas { get; set; }

        [Column("devengamiento_planificado")]
        public double DevengamientoPlanificado { get; set; }

        [Column("horas_trackeadas")]
        public int HorasTrackeadas { get; set; }
    }
}
