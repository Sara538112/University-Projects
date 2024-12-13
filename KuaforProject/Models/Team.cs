namespace b221210566_2_.Models
{
    public class Team
    {
        public ICollection<EmployeeExample> Employees { get; set; }
        public ICollection<SupervisorExample> Supervisor { get; set; }
        public ICollection<ManagerExample> Manager { get; set; }
    }
}
