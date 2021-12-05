using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ProjectService.Application.Common.Constant
{
    public static class CostSummaryItems
    {
        //Master
        public const string MASTER_PRE_DEV_FEED = "Pre-Dev+Feed";
        public const string MASTER_OWNER_COST = "Owner Cost";
        public const string MASTER_FACILITIES_CAPEX = "Facilities CAPEX";
       // public const string MASTER_P50_DRILLING_COST = "P50 Drilling Cost";
        public const string MASTER_P80_DRILLING_COST = "P80 Drilling Cost";
        public const string MASTER_P50_DRILLING_COST = "P50 Drilling Cost (MOD)";
        public const string MASTER_TOTAL_P80_DRILLING_COST = "Total P80 Drilling Cost (MOD)";
        public const string MASTER_FACILITIES_BASE_COST = "Total Facilities Base Cost (RT {{year}})";
        public const string MASTER_ESCALATION_INFLATION_BASE_FACILITIES = "Escalation & Inflation (Base Facilities)";
        public const string MASTER_ESCALATION_AND_INFLATION_FACILITIES_P80DRILLING = "Escalation & Inflation (Base Facilities and P80 Drilling)";
        public const string MASTERL_P50_FACILITIES_CONTINGENCY = "P50 Facilities Contingency @{{percentage}}%";
        //public const string MASTER_TOTAL_P50_PROJECT_CAPEX_YEAR = "Total P50 Project Capex (RT {{year}})";
        //public const string MASTER_TOTAL_P80_PROJECT_CAPEX_YEAR = "Total P80 Project Capex (RT {{year}})";
        public const string MASTER_TOTAL_P50_PROJECT_CAPEX_MOD = "Total P50 Facilities CAPEX (MOD)";
        public const string MASTER_TOTAL_P80_PROJECT_CAPEX_MOD = "Total P80 Project Capex (MOD)";
        public const string MASTERL_MANAGEMENT_RESERVES_FACILITIES = "Management Reserves (Facilities)";
        public const string MASTERL_MANAGEMENT_RESERVES_DRILLING = "Management Reserves (Drilling)";
        public const string MASTER_TOTAL_P80_FACILITIES_CAPEX_MOD = "Total P80 Facilities CAPEX (MOD)";
        //public const string MASTER_ESCALATION_AND_INFLATION_FACILITIES_P80DRILLING = "Escalation and Inflation (Base Facilities and P80 Drilling)"; 
        public const string MASTER_GRAND_TOTAL_P50_PROJECT_CAPEX_MOD = "Grand Total Project P50 CAPEX (MOD)";
        public const string MASTER_GRAND_TOTAL_P80_PROJECT_CAPEX_MOD = "Grand Total P80 Project Capex (MOD)";


        //p50
        public const string P50_P50_DRILLING_COST_MOD = "P50 Drilling Cost (MOD)";
        public const string P50_FACILITIES_CAPEX = "Facilities CAPEX";
        public const string P50_TOTAL_P50_DRILLING_COST = "Total P50 Drilling Cost";
        public const string P50_FACILITIES_BASE_COST_YEAR = "Total Facilities Base Cost (RT {{year}})";
      

        public const string P50_PRE_DEV_FEED = "Pre-Dev+Feed";
        public const string P50_OWNER_COST = "Owner Cost";
        //public const string P50_FACILITIES_CAPEX = "Facilities CAPEX";
        public const string P50_FACILITIES_BASE_COST_YEAR_EXCLUDE_WELLS = "Total Facilities Base Cost (RT {{year}}) - (Excluding Wells)";
        public const string P50_P50_FACILITIES_CONTINGENCY = "P50 Facilities Contingency @{{percentage}}%";
        public const string P50_TOTAL_P50_FACILITIES_CAPEX_MOD= "Total P50 Facilities CAPEX (MOD)";
        public const string P50_ESCALATION_AND_INFLATION = "Escalation & Inflation (Base Facilities)";
        public const string P50_GRAND_TOTAL_P50_PROJECT_CAPEX_MOD = "Grand Total Project P50 CAPEX (MOD)"; 
        

        //p80
        //public const string P80_P50_DRILLING_COST = "P50 Drilling Cost";
        public const string P80_P80_DRILLING_COST = "P80 Drilling Cost";
        public const string P80_FACILITIES_CAPEX = "Facilities CAPEX";
        //public const string P80_TOTAL_P50_DRILLING_COST = "Total P50 Drilling Cost";
        public const string P80_TOTAL_P80_DRILLING_COST = "Total P80 Drilling Cost";
        public const string P80_FACILITIES_BASE_COST_YEAR = "Total Facilities Base Cost (RT {{year}})";
        public const string P80_PRE_DEV_FEED = "Pre-Dev+Feed";
        public const string P80_OWNER_COST = "Owner Cost";
        public const string P80_FACILITIES_BASE_COST_YEAR_EXCLUDE_WELLS = "Total Facilities Base Cost (RT {{year}}) - (Excluding Wells)";
        public const string P80_P50_FACILITIES_CONTINGENCY = "P50 Facilities Contingency @{{percentage}}%";
        public const string P80_MANAGEMENT_RESERVES_FACILITIES = "Management Reserves (Facilities)";
        public const string P80_MANAGEMENT_RESERVES_DRILLING = "Management Reserves (Drilling)";
        public const string P80_TOTAL_P80_PROJECT_CAPEX_YEAR = "Total Project P80 CAPEX (RT {{year}})";
        public const string P80_ESCALATION_AND_INFLATION = "Escalation and Inflation Cost";
        //public const string P80_GRAND_TOTAL_P80_PROJECT_CAPEX_MOD = "Grand Total Project P80 CAPEX (Money of the Day terms)";

        public const string P80_ESCALATION_INFLATION_BASE_FACILITIES = "Escalation & Inflation (Base Facilities)";
        public const string P80_TOTAL_P50_PROJECT_CAPEX_MOD = "Total P50 Facilities CAPEX (MOD)";
        public const string P80_P50_DRILLING_COST = "P50 Drilling Cost (MOD)";
        public const string P80_GRAND_TOTAL_P50_PROJECT_CAPEX_MOD = "Grand Total Project P50 CAPEX (MOD)";
        public const string P80_TOTAL_P80_FACILITIES_CAPEX_MOD = "Total P80 Facilities CAPEX (MOD)";
        public const string P80_GRAND_TOTAL_P80_PROJECT_CAPEX_MOD = "Grand Total P80 Project Capex (MOD)";


        public const string TOTAL_FACILITIES_BASE_COST = "Total Facilities Base Cost (RT {{year}})";
        public const string ESCALATION_INFLATION = "Escalation & Inflation (Base Facilities)";
        public const string TOTAL_P50_FACILITIES_CAPEX = "Total P50 Facilities CAPEX (MOD)";
        public const string P50_DRILLING_COST_MOD = "P50 Drilling Cost (MOD)";
        public const string GRAND_TOTAL_P50_PROJECT = "Grand Total P50 Project CAPEX (MOD)";
        public const string TOTAL_P80_FACILITIES_CAPEX = "Total P80 Facilities CAPEX (MOD)";
        public const string TOTAL_P80_DRILLING_COST = "Total P80 Drilling Cost (MOD)";
        public const string GRAND_TOTAL_P80_PROJECT = "Grand Total P80 Project CAPEX (MOD)";

        public const string P50_P50_DRILLING_COST = "P50 Drilling Cost";
        public const string P50_TOTAL_P50_PROJECT_CAPEX_YEAR = "Total Project P50 CAPEX (RT {{year}})";
        public const string MASTER_ESCALATION_AND_INFLATION_FACILITIES_P50DRILLING = "Escalation & Inflation (Base Facilities and P50 Drilling)";
        //public const string MASTER_TOTAL_P50_PROJECT_CAPEX_MOD = "Total P50 Project Capex (MOD)";
        public const string MASTER_TOTAL_P80_PROJECT_CAPEX_YEAR = "Total P80 Project Capex (RT {{year}})";
        public const string MASTER_TOTAL_P50_PROJECT_CAPEX_YEAR = "Total P50 Project Capex (RT {{year}})";

    }
}
