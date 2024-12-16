using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace b221210566_2_.Models
{
   
        public class  EmployeeExample :User
        {
         
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

            [Required]
            public SalonManager DirectManager { get; set; }
        }
        [Table("HCutEmp")]
        public class HCutEmp : EmployeeExample
        { 
           [Required]
             public HCareSv HCareSv { get; set;
        }


        [Table("HDyeEmp")]
        public class HDyeEmp : EmployeeExample
        {
           [Required]

            public HDyeSv HDyeSv { get; set; }
        }
        
        [Table("HCareEmp")]
        public class HCareEmp : EmployeeExample
        {
             [Required]
             public HCareSv HCareSv { get; set; }

        }

        [Table("ManikurE")]

        public class ManikurE : EmployeeExample
        {
            [Required]
                      public ManikurS ManikurS { get; set; }


        }
        [Table("PadikurE")]

        public class PadikurE : EmployeeExample
        {
            [Required]
            public PadikurS PadikurS { get; set; }

        }
    }
    

