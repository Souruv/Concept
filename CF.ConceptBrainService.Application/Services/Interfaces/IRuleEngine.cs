using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CF.ConceptBrainService.Application.Services.Interfaces
{
    public interface IRuleEngine<T, U>
    {
        public List<T> EvaluateAndGetResult(U inputParam, List<T> formulaDataList, string fieldName);
    }
}
