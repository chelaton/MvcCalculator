namespace Data.Models
{
    public class CalcHistory
    {
        public int Id { get; set; }
        public decimal FirstNumber { get; set; }
        public decimal SecondNumber { get; set; }

        public virtual MathOperator MathOperator { get; set; }
    }
}