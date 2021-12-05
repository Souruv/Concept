using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ConceptBrainService.Application.Common.Interfaces
{
    public interface IMathHelper
    {

        public double EvaluateExpression(string expression);
        public double Ceiling(double value, double significance);
        public double Floor(double value, double significance);
    }
}
