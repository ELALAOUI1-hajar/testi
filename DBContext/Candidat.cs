using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
 
namespace testi.DBContext

{
    public class Candidat
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        public string Nom { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        public string Prenom { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [MaxLength(15)]
        public string Telephone { get; set; }

        [Column(TypeName = "varchar(60)")]
        public string NiveauEtude { get; set; }

        public int AnneesExperience { get; set; }

        [Column(TypeName = "varchar(60)")]
        public string DernierEmployeur { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string CvPath { get; set; }
    }
}
