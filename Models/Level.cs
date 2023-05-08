using System.ComponentModel.DataAnnotations;

namespace E_Exam.Models
{
    public class Level
    {
        public Level()
        {
            Departments = new List<Department>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Department> Departments { get; set; }

    }
}
