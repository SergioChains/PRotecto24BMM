using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models
{
    public class Usuario
    {
        [Key]
         public int PkUser { get; set; }
        public string Nom { get; set; }
        public string user { get; set; }
        public string password { get; set; }

        [ForeignKey("Roles")]
        public int FkRol { set; get; }
        public Rol Roles { get; set; }
    }
}
