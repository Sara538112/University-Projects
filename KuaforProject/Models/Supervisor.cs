using b221210566_2_.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace b221210566_2_.Models
{
    //public abstract class Supervisor
    
        public class SupervisorExample
        {
            [Key]
            public int Id { get; set; } 

            [Required]
            [MinLength(4)]
            public String password { get; set; }

            [Required]
            [MaxLength(50)]
            public string FullName { get; set; }

            [EmailAddress]
            [Required]
            public string EmailAddress { get; set; }


        [Required]
            public byte[] Image { get; set; }

        [Required]
            [ForeignKey("DirectManagerID")]
            public int DirectManagerID { get; set; }
            public SalonManager DirectManager { get; set; }
        }

        [Table("HCutSv")]
        public class HCutSv : SupervisorExample
        {
            public ICollection<HCutEmp> CutEmps { get; set; }
        }

        [Table("HDyeSv")]
        public class HDyeSv : SupervisorExample
        {
            public ICollection<HDyeEmp> DyeEmps { get; set; }
        }

        [Table("HCareSv")]
        public class HCareSv : SupervisorExample
        {
            public ICollection<HCareEmp> CareEmps { get; set; }
        }

        [Table("ManikurS")]
        public class ManikurS : SupervisorExample
        {
            public ICollection<ManikurE> ManuEmps { get; set; }
        }

        [Table("PadikurS")]
        public class PadikurS : SupervisorExample
        {
            public ICollection<PadikurE> PaduEmps { get; set; }
        }
    

}
