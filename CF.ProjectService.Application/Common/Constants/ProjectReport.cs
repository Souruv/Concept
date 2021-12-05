using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ProjectService.Application.Common.Constant
{
    public static class ProjectReport
    {
        public const string RowOne = "1. Cost estimates are in Real Term (RT) {{projectYear}}.";

        public const string RowTwo = "2. The exchange rate applied is based on updated PETRONAS latest KPBI  rate which is 1 USD= RM {{usdToMyrRate}}";

        public const string RowThree = "3. Project is currently in {{getProjectStage}}, thus corresponding to AACEI (Association of Advanced Cost Engineering International) and PPMS (Petronas Project Management System) class estimate of Class {{getClassNumber}}";

        public const string RowFive = "5. The base cost estimates for major facilities are computed based on inhouse software - Que$tor Q1 {{projectYear}} database/tool";

        public const string RowEight = "8. Facilities Base cost  are escalated and inflated based on the cost phasing to obtain its respective Money-of-the-day (MOD) cost.  The facilities CAPEX escalation and inflation index are based on the latest Cost Escalation & Inflation FY {{projectYear1}} for Malaysia & International countries.";

    }
}
