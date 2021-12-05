using CF.ProjectService.Application.Common.Interfaces;
using CF.ProjectService.Application.Features.UserFeatures.Dto;
using Jace;
using Microsoft.Extensions.Configuration;
using Microsoft.Graph;
//using Microsoft.Graph.Auth;
using Microsoft.Identity.Client;
//using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Conceptor.Infrastructure.Service
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

        public double FactorValue(double value,double staticValue)
        {
            double factor = 0;
            if(value == 0)
            {
                return factor * staticValue;
            }
            switch (value)
            {
                case 1:
                    factor = 1;
                    break;
                case 2:
                    factor = 1.15;
                    break;
                case 3:
                    factor = 1.4;
                    break;
                case 4:
                    factor = 2.25;
                    break;
                case 5:
                    factor = 3.5;
                    break;
                default:
                    break;
            }
            return factor * staticValue;
        }
    }
}
