using System;
using System.Collections.Generic;
using System.Text;
using CF.ConceptBrainService.Application.Entities.Base;

namespace CF.ConceptBrainService.Application.Entities
{
    public class BrainTableColumnConfiguration : BaseEntity
    {
        public Guid BrainFieldTableMappingId { get; set; }
        public BrainFieldTableMapping BrainFieldTableMapping { get; set; }
        public string ColumnName { get; set; }
        public string ColumnDataType { get; set; }
        public string CheckOperator { get; set; }
        public bool? IsInput { get; set; }
        public string ConceptInputDetailColumnName { get; set; }
    }
}
