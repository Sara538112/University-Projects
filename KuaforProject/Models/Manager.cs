using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace b221210566_2_.Models
{
    
        public class ManagerExample :User
        {
            
            [Required]
            [MaxLength(50)]
            public string FullName { get; set; }

            [Required]
            public byte[] Image { get; set; }

            [EmailAddress]
            [Required]
            public string EmailAddress { get; set; }

            [Required]
            [MinLength(4)]
            public String password { get; set; }
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
            public GeneralManager DirectManager { get; set; }


            public ICollection <EmployeeExample> Employees { get; set; }
            public ICollection <SupervisorExample> Supervisors { get; set; }

        }

        [Table("FinancialManager")]
        public class FinancialManager : ManagerExample
        {
            [Requird]        
            public GeneralManager DirectManager { get; set; }

        }

    
}
