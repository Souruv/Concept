using CF.ProjectService.Application.Features.UserFeatures.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CF.ProjectService.Application.Common.Interfaces
{
    public interface IMathHelper
    {

        public double EvaluateExpression(string expression);
        public double Ceiling(double value, double significance);
        public double Floor(double value, double significance);
        public double FactorValue(double value,double staticValue);
    }
}
