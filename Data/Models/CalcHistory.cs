using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class CalcHistory
    {
        [Key]
        public int Id { get; set; }
        public string MathFormula { get; set; }
        public decimal Result { get; set; }

    }
}