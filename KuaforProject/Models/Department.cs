using System.ComponentModel.DataAnnotations;

namespace b221210566_2_.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
