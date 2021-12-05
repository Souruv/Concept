namespace CF.ProjectService.Application.Features.ProjectFeatures.Dto
{
    public class ExcelDrillingCenterDto
    {
        public string Name { get; set; }
        public string HyDroCarbonType { get; set; }

        public string HyDroCarbonTypeUnit { get; set; }

        public decimal WaterDepth { get; set; }

        public string WaterDepthUnit { get; set; }


        public string Nature { get; set; }

        public string NatureUnit { get; set; }
        public decimal CITHP { get; set; }

        public string CITHPUnit { get; set; }

        public string TieInLocation { get; set; }

        public string TieInLocationUnit { get; set; }

        public decimal Distance { get; set; }

        public string DistanceUnit { get; set; }

        public string ArtificialLiftType { get; set; }

        public string ArtificialLiftTypeUnit { get; set; }

        public decimal PowerRequirementPerWell { get; set; }

        public string PowerRequirementPerWellUnit { get; set; }

        public ExcelDrillingObjectDto P10 { get; set; }
        public ExcelDrillingObjectDto P50 { get; set; }
        public ExcelDrillingObjectDto P90 { get; set; }

        public OilFluidSpecification MinOilItem { get; set; }

        public OilFluidSpecification MaxOilItem { get; set; }

         public GasFluidSpecification MinGasItem { get; set; }

        public GasFluidSpecification MaxGasItem { get; set; }

        public string GOR { get; set; }

        public string GORUnit { get; set; }

        public string LGR { get; set; }

        public string LGRUnit { get; set; }

        public string CGR { get; set; }

        public string CGRUnit { get; set; }

        public string WellTestRequirement { get; set; }

        public string WellTestRequirementUnit { get; set; }


        public decimal CarbonDioxide { get; set; }
        public decimal HydrogenSulphide { get; set; }
        public decimal Salt { get; set; }
        public decimal Mercaptan { get; set; }
        public decimal Mercury { get; set; }


    }

    public class OilFluidSpecification
    {
        public decimal CarbonDioxide { get; set; }
        public string CarbonDioxideUnit { get; set; }

        public decimal HydrogenSulphide { get; set; }
        public string HydrogenSulphideUnit { get; set; }

        public decimal Salt { get; set; }
        public string SaltUnit { get; set; }

        public decimal Mercaptan { get; set; }
        public string MercaptanUnit { get; set; }
        public decimal Mercury { get; set; }

        public string MercuryUnit { get; set; }

        public decimal WAT { get; set; }

        public string WATUnit { get; set; }

        public string Sand { get; set; }
        public string SandUnit { get; set; }


        public decimal APIGravity { get; set; }
        public string APIGravityUnit { get; set; }








    }

     public class GasFluidSpecification
    {
        public string CarbonDioxide { get; set; }
        public string CarbonDioxideUnit { get; set; }
        public decimal HydrogenSulphide { get; set; }
        public string HydrogenSulphideUnit { get; set; }
        public decimal Mercaptan { get; set; }
        public string MercaptanUnit { get; set; }
        public decimal Mercury { get; set; }
        public string MercuryUnit { get; set; }
        public string Sand { get; set; }
        public string SandUnit { get; set; }

    }
}
