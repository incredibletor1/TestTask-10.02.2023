using System.ComponentModel.DataAnnotations;

namespace TestTask_10._02._2023.Models
{
    /// <summary>
    /// Database Employee model
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Employee Primary Key
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Employee FullName
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// Employee BirthDate
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        /// <summary>
        /// Employee Positions collection
        /// </summary>
        public List<Position> Positions { get; set; } = new();
    }
}
