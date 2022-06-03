﻿using Data.Repository;

namespace Core.Services
{
    public class MathService : IMathService
    {
        private readonly ICalcRepository _calcRepository;

        public MathService(CalcRepository calcRepository)
        {
            _calcRepository = calcRepository;
        }

        public decimal? GetMathResult(string mathFormula)
        {
            if (mathFormula.Length > 0)
            {
                var formulaParts = mathFormula.Split(";");
                Validate(formulaParts);


                var mathOperators = _calcRepository.GetMathOperators().ToList();

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
                        switch (operationName)
                        {
                            case "Scitani":
                                return firstNumber + secondNumber;

                            case "Odcitani":
                                return firstNumber - secondNumber;

                            case "Nasobeni":
                                return firstNumber * secondNumber;

                            case "Deleni":
                                if (secondNumber == 0)
                                {
                                    // call error
                                    throw new Exception("You cannot divide by 0");
                                }
                                return firstNumber / secondNumber;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        //call error not found operator
                        throw new Exception($"Cannot find your math operation {formulaParts[1]}");
                    }

                }
            }
            return null;
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
