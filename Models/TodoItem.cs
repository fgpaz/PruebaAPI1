using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("TodoItem")]
    public class TodoItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_Todo")]
        public long Id { get; set; }

        [Required]
        [Column("Name")]
        [MaxLength(50)]
        public string? Name { get; set; }
        
        [Required]
        [Column("isCompleted")]
        public bool IsCompleted { get; set; }
        
        [Required]
        [Column("eliminado")]
        public bool Eliminado { get; set; }

        [Column("fecha_creacion")]
        public DateTime fecha_creacion { get; set; }
        
        [Column("fecha_modificacion")]
        public DateTime fecha_modificacion { get; set; }
    }
}