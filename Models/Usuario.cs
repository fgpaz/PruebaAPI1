using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("usuario")]
    public class Usuario : EntidadBase
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("id_usuario")]
        public int Id { get; set; }

        [Column("nombre")]
        public string? Nombre { get; set; }

        [Column("email")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Column("fecha_creacion")]
        [DataType(DataType.Date)]
        public DateTime FechaCreacion { get; set; }

        [Column("rol")]
        public Rol Rol { get; set; }

        [Column("fecha_modificacion")]
        [DataType(DataType.Date)]
        public DateTime FechaModificacion { get; set; }

        [Column("sbu")]
        public string? Sbu { get; set; }
    }
}
