using System;
using System.Collections.Generic;
using System.Text;
using CF.ConceptBrainService.Application.Common.Interfaces;
using Jace;

namespace CF.ConceptBrainService.Infrastructure.Helper
{
    public class MathHelper : IMathHelper
    {
        public double EvaluateExpression(string expression)
        {
            var engine = new CalculationEngine();
            return engine.Calculate(expression);
        }

        public double Ceiling(double value, double significance)
        {
            if ((value % significance) != 0)
            {
                return ((int)(value / significance) * significance) + significance;
            }

            return Convert.ToDouble(value);
        }



        public double Floor(double value, double significance)
        {
            if ((value % significance) != 0)
            {
                return ((int)(value / significance) * significance);
            }

            return Convert.ToDouble(value);
        }
    }
}
