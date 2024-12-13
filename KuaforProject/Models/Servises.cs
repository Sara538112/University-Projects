using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace b221210566_2_.Models
{

    public class Servises
    {
        public class servisesExample
        {
            public string DepName { get; set; }
            public string Description { get; set; }

        }

        [Table("HCut")]
        [Display(Name = "Hair Cut")]
      
        public class HCut : servisesExample
        {
            public HCutSv Supervisor { get; set; }

            public ICollection <HCutEmp> employees {get; set;} 
        }

        [Table("HCare")]
        [Display(Name = "Hair Care")]
        public class HCare : servisesExample
        {
            public HCareSv Supervisor { get; set; }// this can't be Key
            public ICollection<HCareEmp> employees { get; set; }

        }

        [Table("HDye")]
        [Display(Name = "Hair Dye")]
        public class HDye : servisesExample
        {
            public HDyeSv supervisor { get; set; }

            public ICollection<HDyeEmp> employees { get; set; }
        }

        [Table("Manikur")]
        [Display(Name = "Manikur")]
        public class Manikur : servisesExample
        {
            public ManikurS Supervisor { get; set; }
            public ICollection<ManikurE> employees { get; set; }

        }


        [Table("Pedikur")]
        [Display(Name = "Pedikur")]
        public class Pedikur : servisesExample
        {
            public PadikurS Supervisor { get; set; }
            public ICollection<PadikurE> employees { get; set; }

        }
    }
}
