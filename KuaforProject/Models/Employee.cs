using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace b221210566_2_.Models
{
   
        public class  EmployeeExample
        {
            [Key]
            public int Id { get; set; }

            [Required]
            [MinLength(4)]
            public String password { get; set; }

            [Required]
            [MaxLength(50)]
            public string FullName { get; set; }

            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            public byte[] Image { get; set; }


            
        [ForeignKey("DirectManagerID")]
            public int DirectManagerID { get; set; }
            public SalonManager DirectManager { get; set; }
        }
        [Table("HCutEmp")]
        public class HCutEmp : EmployeeExample
        {

            [Required]
            [ForeignKey("SupervisorID")]
            public int SupervisorID { get; set; }
            public  HCutSv SupervisorC { get; set; }
            
        }


        [Table("HDyeEmp")]
        public class HDyeEmp : EmployeeExample
        {


            [Required]
            [ForeignKey("SupervisorID")]
            public int SupervisorID { get; set; }
            public HDyeSv SupervisorD { get; set; }

        }
        
        [Table("HCareEmp")]
        public class HCareEmp : EmployeeExample
        {


            [Required]
            [ForeignKey("SupervisorID")]
            public int SupervisorID { get; set; }
            public  HCareSv SupervisorCR { get; set; }

        }

        [Table("ManikurE")]

        public class ManikurE : EmployeeExample
        {
            [Required]
            [ForeignKey("SupervisorID")] 
            public int SupervisorID { get; set; }
            public  ManikurS SupervisorM { get; set; }

        }
        [Table("PadikurE")]

        public class PadikurE : EmployeeExample
        {
            [Required]
            [ForeignKey("SupervisorID")]
            public int SupervisorID { get; set; }
            public  PadikurS SupervisorP { get; set; }

        }
    }
    

