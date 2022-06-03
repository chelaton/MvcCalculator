using Data.Repository;

namespace Core.Services
{
    public class MathService
    {
        private readonly ICalcRepository _calcRepository;

        public MathService(CalcRepository calcRepository)
        {
            _calcRepository = calcRepository;
        }


    }
}
