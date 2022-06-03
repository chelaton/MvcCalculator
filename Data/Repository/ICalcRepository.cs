using Data.Models;

namespace Data.Repository
{
    public interface ICalcRepository
    {
        IQueryable<CalcHistory> GetCalcHistories();
        IQueryable<MathOperator> GetMathOperators();
        void InsertToCalcHistory(CalcHistory calcHistory);
        void SaveChanges();
    }
}