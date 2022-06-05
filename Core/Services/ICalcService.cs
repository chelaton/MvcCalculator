using Core.DTOs;

namespace Core.Services
{
    public interface ICalcService
    {
        IEnumerable<string> GetCalcHistories();
        decimal? GetMathResult(string mathFormula);
    }
}