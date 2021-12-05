namespace CF.CostBrainService.Application.Services.Interfaces
{
    public interface IMathHelper
    {

        public double EvaluateExpression(string expression);
        public double Ceiling(double value, double significance);
        public double Floor(double value, double significance);
        public double FactorValue(double value,double staticValue);
    }
}
