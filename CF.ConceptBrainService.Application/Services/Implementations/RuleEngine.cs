using CF.ConceptBrainService.Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CF.ConceptBrainService.Application.Features.ConceptBrainSettingFeatures.Dto;
using CF.ConceptBrainService.Application.Features.ConceptBrainSettingFeatures.Dto.InputDto;
using System.Linq.Dynamic.Core;
using CF.ConceptBrainService.Application.Common.Interfaces;
using System.Linq;
using CF.ConceptBrainService.Application.Entities;

namespace CF.ConceptBrainService.Application.Services.Implementations
{
    public class RuleEngine<T, U> : IRuleEngine<T, U>
    {
        private readonly IUnitOfWork _unitOfWork;
        BrainFieldTableMapping brainFieldTableMappingsLst = null;
        List<BrainTableColumnConfiguration> brainTableColumnConfigurationsLst = null;
        List<LambdaExpression> ruleList = new List<LambdaExpression>();
        string whereClase = "";
        string selectColList = string.Empty;
        internal U Input;
        public RuleEngine(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void LoadFormulaConfigurationData(string fieldName)
        {
            brainFieldTableMappingsLst = _unitOfWork.BrainFieldTableMappingRepository.Filter(x => !x.IsDeleted && x.FieldName == fieldName).FirstOrDefault();
            if(brainFieldTableMappingsLst != null) { 
            brainTableColumnConfigurationsLst = _unitOfWork.BrainTableColumnConfigurationRepository.Filter(x => !x.IsDeleted
            && x.BrainFieldTableMappingId == brainFieldTableMappingsLst.Id).ToList();
            }
        }

        public List<T> EvaluateAndGetResult(U inputParam,List<T> formulaDataList, string fieldName)
        {
            
            this.Input = inputParam;
            this.LoadFormulaConfigurationData(fieldName);
            this.BuildExpression();
            var result = ruleList.Count>0?formulaDataList.AsQueryable().Where(whereClase, ruleList.ToArray()): formulaDataList.AsQueryable();

            return result.ToList();
        }

        public void BuildExpression()
        {
            ruleList.Clear();
            int counter = 0;
            whereClase = string.Empty;

            Expression<Func<T, bool>> e = null;
            foreach (var config in this.brainTableColumnConfigurationsLst.Where(x => x.IsInput == true))
            {
                if (this.Input.GetType().GetProperty(config.ConceptInputDetailColumnName).GetValue(this.Input, null) != null)
                {
                    e = DynamicExpressionParser.ParseLambda<T, bool>(new ParsingConfig(), true,
                        "c =>c." + config.ColumnName + "== null ||   @0." + config.ConceptInputDetailColumnName + " " + config.CheckOperator + " c." + config.ColumnName
                        , this.Input);

                    ruleList.Add(e);

                    whereClase += (counter == 0 ? "@" + counter + "(it)" : " and @" + counter + "(it)");
                    counter++;
                }

            }
            counter = 0;
            foreach (var config in this.brainTableColumnConfigurationsLst.Where(x => x.IsInput == false))
            {

                selectColList += (counter > 0 ? "," : "") + config.ColumnName;
                counter++;
            }
        }
    }
}
