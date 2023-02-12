using System.ComponentModel.DataAnnotations;

namespace TestTask_10._02._2023.Models.VM
{
    /// <summary>
    /// Position View Model
    /// </summary>
    public class PositionVM
    {
        /// <summary>
        /// Position Primary Key
        /// </summary>
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
    }
}
