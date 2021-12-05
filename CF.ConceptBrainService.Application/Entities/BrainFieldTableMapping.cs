using System;
using System.Collections.Generic;
using System.Text;
using CF.ConceptBrainService.Application.Entities.Base;

namespace CF.ConceptBrainService.Application.Entities
{
    public class BrainFieldTableMapping : BaseEntity
    {
        public string FieldName { get; set; }
        public string TableName { get; set; }
        public string FieldType { get; set; }
        public string OutputColumnName { get; set; }
        public string FieldDisplayName { get; set; }
        public string OutputColumnDisplayName { get; set; }
        public int ExecSequence { get; set; }
        public string ExecLevel { get; set; }
    }
}
