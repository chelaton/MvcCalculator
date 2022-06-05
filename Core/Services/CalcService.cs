using Core.DTOs;
using Data.Models;
using Data.Repository;

namespace Core.Services
{
    public class CalcService : ICalcService
    {
        private readonly ICalcRepository _calcRepository;

        public CalcService(ICalcRepository calcRepository)
        {
            _calcRepository = calcRepository;
        }

        public decimal? GetMathResult(string mathFormula)
        {
            var calcHistoryLog = new CalcHistory();
            if (mathFormula.Length > 0)
            {
                var mathOperators = _calcRepository.GetMathOperators().ToList();
                var formulaParts = SplitFormulaToParts(mathFormula, mathOperators);

                foreach (var item in formulaParts)
                {
                    calcHistoryLog.MathFormula += item;
                }

                Validate(formulaParts);

                if (formulaParts.Count() == 3) //most basic example
                {
                    if (!Decimal.TryParse(formulaParts[0], out decimal firstNumber))
                    {

                        //callError
                        throw new Exception($"Cannot convert first number {formulaParts[0]}");
                    }
                    if (!Decimal.TryParse(formulaParts[2], out decimal secondNumber))
                    {
                        //callError
                        throw new Exception($"Cannot convert second number {formulaParts[2]}");
                    }
                    if (mathOperators.Any(p => p.Symbol.Equals(formulaParts[1])))
                    {
                        var operationName = mathOperators.Where(p => p.Symbol.Equals(formulaParts[1])).Select(s => s.OperationName).FirstOrDefault();
                        decimal result = 0;
                        switch (operationName)
                        {
                            case "Scitani":
                                result= firstNumber + secondNumber;
                                break;

                            case "Odcitani":
                                result = firstNumber - secondNumber;
                                break;

                            case "Nasobeni":
                                result = firstNumber * secondNumber;
                                break;

                            case "Deleni":
                                if (secondNumber == 0)
                                {
                                    // call error
                                    throw new Exception("You cannot divide by 0");
                                }
                                result = firstNumber / secondNumber;
                                break;
                            default:
                                break;
                        }
                        calcHistoryLog.Result=result;
                        _calcRepository.InsertToCalcHistory(calcHistoryLog);
                        _calcRepository.SaveChanges();
                        return result;
                    }
                    else
                    {
                        //call error not found operator
                        throw new Exception($"Cannot find your math operation {formulaParts[1]}");
                    }

                }
                else
                {
                    throw new Exception("Sorry I dont know how to count this.");
                }
            }
            return null;
        }

        public IEnumerable<string> GetCalcHistories()
        {
            var calcHistoryList = _calcRepository.GetCalcHistories().OrderByDescending(p => p.Id).Take(10).DefaultIfEmpty().ToList();
            var calcHistoryStringList = new List<string>();
            foreach (var item in calcHistoryList)
            {
                var oneHistory = item.MathFormula + " = " + item.Result;
                calcHistoryStringList.Add(oneHistory);
            }
            return calcHistoryStringList;
        }
        private string[]? SplitFormulaToParts(string mathFormula, List<MathOperator> mathOperators)
        {
            mathFormula.Replace(" ", "");
            string mathFormulaWithSpacers = "";
            for (int i = 0; i < mathFormula.Length; i++)
            {   
                var oneChar = mathFormula[i].ToString();
                if (mathOperators.Any(p => p.Symbol.Equals(oneChar)))
                {
                    mathFormulaWithSpacers += " "+ oneChar+" ";
                    continue;
                }
                mathFormulaWithSpacers += oneChar;
            }
            var parts = mathFormulaWithSpacers.Split(' ');
            return parts;
        }

        private void Validate(string[] formulaParts)
        {
            if (formulaParts.Count() < 3) //minimal count is 3
            {
                throw new Exception($"Its imposible to count");
            }
        }

    }
}
