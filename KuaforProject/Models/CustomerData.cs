using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace b221210566_2_.Models
{
    [Table("CustomerData")]
    public class CustomerData :User
    {

        [Required]
        [MinLength(4)]
        public String password { get; set; }

        [Required]
        [Column("Name")]
        public string CustomerName { get; set; }

        [Required]
        [Column("Email")]
        [EmailAddress]
        public string CustomerEmail { get; set; }


        [Required]
        [Column("Phone")]
        public string CustomerPhone { get; set; }


    }
}
