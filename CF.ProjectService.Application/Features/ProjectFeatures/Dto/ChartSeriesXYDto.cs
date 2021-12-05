using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ProjectService.Application.Features.ProjectFeatures.Dto
{


    public class ChartSeriesXYDto<T, U>
    {
        public string Title { get; set; }

        //public Dictionary<T, U> Series { get; set; } = new Dictionary<T, U>();
        public Dictionary<string, XYValue<T, U>> Series { get; set; } = new Dictionary<string, XYValue<T, U>>();
    }

    public class XYValue<T,U>{
        public T XValue { get; set; }
        public U YValue { get; set; }
    }
}
