using System.ComponentModel.DataAnnotations;

namespace TestTask_10._02._2023.Models
{
    /// <summary>
    /// Database Position model
    /// </summary>
    public class Position
    {
        /// <summary>
        /// Position Primary Key
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Position Name 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Position Grade 
        /// </summary>
        [RegularExpression("^([1-9]|1[0-5])$", ErrorMessage = "Value must be between 1-15")] // Regex for 1-15 range
        public int Grade { get; set; }
        /// <summary>
        /// Position Employees collection
        /// </summary>
        public List<Employee> Employees { get; set; } = new();
    }
}
