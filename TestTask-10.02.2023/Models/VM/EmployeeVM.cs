using System.ComponentModel.DataAnnotations;

namespace TestTask_10._02._2023.Models.VM
{
    /// <summary>
    /// Employee View Model
    /// </summary>
    public class EmployeeVM
    {
        /// <summary>
        /// Employee Primary Key
        /// </summary>
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
        /// Employee PositionsIds collection
        /// </summary>
        public List<int> PositionsIds { get; set; } = new List<int>();
    }
}
