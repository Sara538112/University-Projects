using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace b221210566_2_.Models
{
    public abstract class Manager
    {
        public class ManagerExample()
        {
            [Key]
            public int Id { get; set; }

            [Required]
            [MaxLength(50)]
            public string FullName { get; set; }

            [EmailAddress]
            [Required]
            public string EmailAddress { get; set; }
        }
        [Table("GeneralManager")]
        public class GeneralManager :ManagerExample
        {
            public ICollection<EmployeeExample> SalonEmployees { get; set; }
            public ICollection<SupervisorExample> Supervisors { get; set; }
            public ICollection<FinancialManager> FinancialManagers { get;  set; }

            public ICollection<SalonManager> salonManagers {  get; set; }

        }

        [Table("SalonManager")]
        public class SalonManager :ManagerExample
        {

            [ForeignKey("DirectManagerID")]
            public int DirectManagerID { get; set; }
            public GeneralManager DirectManager { get; set; }

            public ICollection <EmployeeExample> Employees { get; set; }
            public ICollection <SupervisorExample> Supervisors { get; set; }

        }

        [Table("FinancialManager")]
        public class FinancialManager : ManagerExample
        {
           
            [Required]
            [ForeignKey("DirectManagerID")]
            public int DirectManagerID { get; set; }
            public GeneralManager DirectManager { get; set; }
        }

    }
}
