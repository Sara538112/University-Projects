using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace b221210566_2_.Models
{
    [Table("CustomerData")]
    public class CustomerData
    {

        [ForeignKey ("AppNo")]
        [Column("AppNo")]
        public int AppNo { get; set; }
        public SalonOperation.Appointments appointment { get; set; }

        [Key]
        [Column ("CID")]
        public int CID { get; set; }

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

        [Required]
        [Column("Procedure")]
        public string Procedure { get; set; }

        [Required]
        [Column("AppDate")]
        public string AppDate { get; set; }

        [Required]
        [Column("AppTime")]
        public string AppTime { get; set; }
    }
}
