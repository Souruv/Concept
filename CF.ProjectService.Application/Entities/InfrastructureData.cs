using CF.ProjectService.Application.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ProjectService.Application.Entities
{
    public class InfrastructureData : BaseEntity
    {
        public Guid ProjectRevisionId { get; set; }
        public string Region { get; set; }
        public string Location { get; set; }

        public IList<EvacuationOption> EvacuationOptions { get; set; }
        public IList<EvacuationOptionCondensate> EvacuationOptionCondensates { get; set; }
        public IList<EvacuationOptionGas> EvacuationOptionGas { get; set; }
        public IList<EvacuationOptionOil> EvacuationOptionOils { get; set; }
        public IList<EvacuationOptionProducedWater> EvacuationOptionProducedWaters { get; set; }

        public ProjectRevision ProjectRevision { get; set; }
        //public decimal EvacuationPermissible { get; set; }
        //public string EvacuationPermissibleUnit { get; set; }
        //public decimal EvacuationMaxCo2 { get; set; }
        //public string EvacuationMaxCo2Unit { get; set; }
        //public decimal EvacuationMaxH2s { get; set; }
        //public string EvacuationMaxH2sUnit { get; set; }
        //public decimal EvacuationSalt { get; set; }
        //public string EvacuationSaltUnit { get; set; }
        //public decimal EvacuationPressure { get; set; }
        //public string EvacuationPressureUnit { get; set; }

        //public decimal TieInPermissible { get; set; }
        //public string TieInPermissibleUnit { get; set; }
        //public decimal TieInMaxCo2 { get; set; }
        //public string TieInMaxCo2Unit { get; set; }
        //public decimal TieInMaxH2s { get; set; }
        //public string TieInMaxH2sUnit { get; set; }
        //public decimal TieInSalt { get; set; }
        //public string TieInSaltUnit { get; set; }
        //public decimal TieInPressure { get; set; }
        //public string TieInPressureUnit { get; set; }

        //public decimal DedicatedPermissible { get; set; }
        //public string DedicatedPermissibleUnit { get; set; }
        //public decimal DedicatedMaxCo2 { get; set; }
        //public string DedicatedMaxCo2Unit { get; set; }
        //public decimal DedicatedMaxH2s { get; set; }
        //public string DedicatedMaxH2sUnit { get; set; }
        //public decimal DedicatedSalt { get; set; }
        //public string DedicatedSaltUnit { get; set; }
        //public decimal DedicatedPressure { get; set; }
        //public string DedicatedPressureUnit { get; set; }
    }
}
