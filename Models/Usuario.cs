using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Models
{
    [Table("usuario")]
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("id_usuario")]
        public int Id { get; set; }

        [Column("nombre")]
        public string? Nombre { get; set; }

        [Column("email")]
        public string? Email { get; set; }

        [Column("fecha_creacion")]
        public DateTime Fecha_creacion { get; set; }

        //[Column("rol")]
        //public roles Rol { get; set; }

        [Column("fecha_modificacion")]
        public DateTime Fecha_modificacion { get; set; }

        [Column("sbu")]
        public string? Sbu { get; set; }
    }
}
