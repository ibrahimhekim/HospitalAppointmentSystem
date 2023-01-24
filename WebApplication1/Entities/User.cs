using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Entities
{
    [Table("Users")] //Veritabanındaki tablo adına karşılık gelir
    public class User
    {
        [Key] 
        public Guid Id { get; set; } //sql uniqe id
        [StringLength(50)]
        public string? FullName { get; set; } = null;
        [Required]
        [StringLength(30)]
        public string Username { get; set; }
        [Required]
        [StringLength(100)]
        public string Password { get; set; }
        public bool Locked { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
