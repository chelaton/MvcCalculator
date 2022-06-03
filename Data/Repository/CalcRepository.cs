using Data.Models;

namespace Data.Repository
{
    public class CalcRepository : ICalcRepository
    {
        private readonly CalcContext _calcContext;

        public CalcRepository(CalcContext calcContext)
        {
            _calcContext = calcContext;
        }

        public IQueryable<CalcHistory> GetCalcHistories()
        {
            return _calcContext.CalcHistories;
        }

        public void InsertToCalcHistory(CalcHistory calcHistory)
        {
            _calcContext.CalcHistories.Add(calcHistory);
        }
        public void SaveChanges()
        {
            _calcContext.SaveChanges();
        }
    }
}
