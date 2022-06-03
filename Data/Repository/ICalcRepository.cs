using Data.Models;

namespace Data.Repository
{
    public interface ICalcRepository
    {
        IQueryable<CalcHistory> GetCalcHistories();
        void InsertToCalcHistory(CalcHistory calcHistory);
        void SaveChanges();
    }
}