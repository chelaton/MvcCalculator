namespace Core.Services
{
    public interface ICalcService
    {
        decimal? GetMathResult(string mathFormula);
    }
}