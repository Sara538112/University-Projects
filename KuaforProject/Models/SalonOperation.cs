using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace b221210566_2_.Models
{
    public class SalonOperation
    {
        
        //for customers
        [Table("Appointments")]
        public class Appointments
        {
            [Key]
            public int AppNo { get; set; } // this key is for Appointments not for SalonOperation

            [Required]
            public DateFormat AppDate { get; set; }

            [Required]
            public DateTime AppTime { get; set; }

            [Required]
            public string Department { get; set; }

            [Required]
            [MaxLength(50)]
            public String EmployeeName { get; set; }

            [Required]
            public int Period { get; set; }

            [Required]
            public float Coast {  get; set; }

            [Required]
            //radevu alan kisi supervisor
            [ForeignKey("SupervisorID")]
            public int SupervisorID { get; set; }

            public SupervisorExample Supervisor { get; set; }

            [Required]
            public bool IsApproved { get; set; }
        }

        //for manager and supervisors

        [Table("Scudle")]
        public class Scudle
        {
            [Key]
            public int AppNo { get; set; }

            [Required]
            public DateFormat AppDate { get; set; }

            [Required]
            public DateTime AppTime { get; set; }

            [Required]
            public string Department { get; set; }

            [Required]
            [MaxLength(50)]
            public string EmployeeName { get; set; }

            [Required]
            public int Period { get; set; }

            [Required]
            //genel salonun plani gorebilen manager
            [ForeignKey("ManagerID")]
            public int ManagerID { get; set; }
            public  SalonManager Manager { get; set; }
        }
    }
}
