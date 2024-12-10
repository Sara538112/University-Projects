using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace b221210566_2_.Models
{
    public class Servises
    {
       

        [Table("HCut")]
        [Display(Name ="Hair Cut")]
        public class HCut() 
        {
           public HCutSv Supervisor { get; set; }
           public string Description { get; set; }
        }

        [Table("HCare")]
        [Display(Name = "Hair Care")]
        public class HCare
        {
           public HCareSv Supervisor { get; set; }// this can't be Key
           public string Description { get; set; }
        }

        [Table("HDye")]
        [Display(Name = "Hair Dye")]
        public class HDye()
        {
           public HDyeSv supervisor { get; set; }
           public string Description { get; set; }
        }

        [Table("Manikur")]
        [Display(Name = "Manikur")]
        public class Manikur()
        {
          public ManikurS Supervisor { get; set; }
           public string Description { get; set; }
        }


        [Table("Pedikur")]
        [Display(Name = "Pedikur")]
        public class Pedikur()
        {
          public PadikurS Supervisor { get; set; }
           public string Description { get; set; }
        }
    }
}
