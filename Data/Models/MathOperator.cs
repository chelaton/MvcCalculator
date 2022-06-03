using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class MathOperator
    {
        [Key]
        public int Id { get; set; }
        public string OperationName { get; set; }
        public string Symbol { get; set; }
    }
}
