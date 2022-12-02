using Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Concrete
{
    public class Customer : IEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "E-posta alanı boş olamaz.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi değil. Örnek: bilgi@abc.com")]
        public string Email { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "Telefon alanı boş olamaz.")]
        public string Phone { get; set; }
        public string Address { get; set; }


    }
}
