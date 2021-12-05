using CF.ProjectService.Application.Common.Enums;
using CF.ProjectService.Application.Common.Interfaces;
using CF.ProjectService.Application.Entities;
using CF.ProjectService.Application.Features.ProjectFeatures.Dto;
using CF.ProjectService.Application.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Spire.Pdf;
using Spire.Pdf.AutomaticFields;
using Spire.Pdf.Graphics;
using Spire.Pdf.Print;
using Spire.Pdf.Widget;
using Spire.Xls;
using Spire.Xls.Charts;

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CF.ProjectService.Application.Services.Implementations
{
    public class ProjectReportService : IProjectReportService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMathHelper _mathHelper;
        const string MalayCurr = "MYR";
        const string ExchangeRate = "1 MYR = 0.265 USD";

        public ProjectReportService(IUnitOfWork unitOfWork, IMathHelper mathHelper)
        {
            _unitOfWork = unitOfWork;
            _mathHelper = mathHelper;
        }

        public async Task<MemoryStream> CreateCRAReport(decimal baseEstimate, decimal totalRiskScore, string estimateClass, string curve, Guid revisionId, string filePath, string fileType)
        {
            var stream = new MemoryStream();

            var workbook = new Workbook();
            workbook.LoadFromFile(filePath);
            //Get the CRAReport object
            var retObj = await GetCraData(baseEstimate, totalRiskScore, estimateClass, curve);

            //Get the project details
            var revision = await _unitOfWork.RevisionRepository.GetSingleAsync(x => x.Id == revisionId && x.IsDeleted == false,
                 source => source.Include(x => x.Project).Include(x => x.ProjectStage));

            string projectName = revision.Project.Name;
            //entering header values
            workbook = FillDataHeader(workbook, retObj);
            // fill data to probability sheet and draw chart
            workbook = DrawProbabilityFunctionChart(workbook, retObj, baseEstimate, totalRiskScore, estimateClass, revisionId, revision);
            // draw cummulative chart
            workbook = DrawCumalativeFunctionChart(workbook, retObj);
            // fill data to costRange sheet
            workbook = FillDataToCostRangeTable(workbook, retObj, baseEstimate);
            var projectDetValues = GetProjectDeterministicVales(revisionId);

            //Entering Deterministic Values
            InsertDeterMinisticValuesStructure(projectDetValues, workbook, estimateClass);

            // draw spider chart
            workbook = DrawSpiderChart(workbook, retObj);


            if (fileType == "pdf")
            { 
                workbook.Worksheets[0].PageSetup.CenterHorizontally = true;
                workbook.Worksheets[0].PageSetup.CenterFooter = "&\"Arial\"&7&B&KBFBFBFAll rights reserved. No part of this document may be reproduced, stored in a retrieval system or transmitted in any form or by any means (electronic, mechanical, photocopying, recording or otherwise) without the permission of the copyright owner. This document is for PETRONAS internal use only and is not for distribution to the public by sale or for communication to the public.";


                for (int i = 0; i < workbook.Worksheets.Count; i++)
                {
                    workbook.Worksheets[i].PageSetup.FitToPagesTall = 0;
                    workbook.Worksheets[i].PageSetup.FitToPagesWide = 1;
                    workbook.Worksheets[i].PageSetup.CenterHorizontally = false;

                }
                workbook.Worksheets[14].Visibility = WorksheetVisibility.Hidden;

                workbook.SaveToFile("Report.pdf", Spire.Xls.FileFormat.PDF);
                PdfDocument doc = new PdfDocument();
                doc.LoadFromFile("Report.pdf");
                PdfUnitConvertor unitCvtr = new PdfUnitConvertor();
                PdfMargins margin = new PdfMargins();
                margin.Top = unitCvtr.ConvertUnits(2.54f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
                margin.Bottom = margin.Top;
                margin.Left = unitCvtr.ConvertUnits(3.15f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
                margin.Right = margin.Left;
                //traverse each page in the document 
                for (int i = doc.Pages.Count - 1; i >= 0; i--)
                {
                    //detect if a page is blank
                    //There is a bug in isblank method it always returns false even for blank pages
                    //This issue is resolved in spire.pdf higher version 7.50
                    //https://www.e-iceblue.com/forum/pdfpage-isblank-return-always-false-t10128.html
                    PdfPageBase originalPage = doc.Pages[i];
                    string text = originalPage.ExtractText();
                    if (text == null || text.Trim().Length == 0 || doc.Pages[i].IsBlank())
                    {
                        //remove the blank page 
                        doc.Pages.RemoveAt(i);
                    }
                }
                DrawPageNumber(doc.Pages, margin, 1, doc.Pages.Count);
                var pdfStream = new MemoryStream();

                doc.SaveToStream(pdfStream);

                if (File.Exists(Directory.GetCurrentDirectory() + @"\Report.pdf"))
                {
                    File.Delete(Directory.GetCurrentDirectory() + @"\Report.pdf");
                }

                return pdfStream;
            }

            workbook.SaveToStream(stream);

            return stream;
        }
        private Workbook FillDataToCostRangeTable(Workbook workbook, CraReportDto retObj, decimal baseEstimate)
        {
            var costRangeSheet = workbook.Worksheets[5];
            var objCostRange = GetCostRangeTableObject(retObj.CostRangeTable);
            var dt = GetDataTableFromObjects(objCostRange);
            costRangeSheet.InsertDataTable(dt, false, 15, 2);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                double.TryParse(costRangeSheet.Range[$"D{15 + i}"].Value, out double number);
                if (number < 0)
                {
                    var temp = (number * -1).ToString();
                    costRangeSheet.Range[$"D{15 + i}"].Value = "'(" + temp + ")";
                    costRangeSheet.Range[$"D{15 + i}"].Style.Font.Color = Color.Red;
                }
            }
            ////Entering the values in estimate summary table
            var baseEst = Math.Round(baseEstimate, 2).ToString() + " M";
            var p50Est = Math.Round(retObj.P50Estimate, 3).ToString() + " M";
            var p90Est = Math.Round(retObj.P90Estimate, 3).ToString() + " M";
            var p10Est = Math.Round(retObj.P10Estimate, 3).ToString() + " M";
            //var p90EstPercBase = Math.Round(retObj.P90EstimatePercentageOfBase, 2).ToString() + "%";
            costRangeSheet.Range[$"C7"].Value = baseEst.Replace("M", string.Empty);
            costRangeSheet.Range[$"C8"].Value = Convert.ToString(retObj.BaseEstimateContingency);
            //double contContingency = Math.Round(retObj.BaseEstimateContingency - double.Parse(baseEst.Replace("M", string.Empty))/ double.Parse(baseEst.Replace("M", string.Empty)),3) * 100;
            costRangeSheet.Range[$"E8"].Value = retObj.ContingencyPercentageOfBase.ToString() + "%";

            costRangeSheet.Range[$"C9"].Value = p50Est.Replace("M", string.Empty);
            costRangeSheet.Range[$"C10"].Value = p10Est.Replace("M", string.Empty);
            costRangeSheet.Range[$"C11"].Value = p90Est.Replace("M", string.Empty);

            double contA = Math.Round(((retObj.P90Estimate - retObj.P50Estimate) / retObj.P50Estimate) * 100, 0);
            double contB = Math.Round(((retObj.P10Estimate - retObj.P50Estimate) / retObj.P10Estimate) * 100, 0);

            costRangeSheet.Range[$"E10"].Value = string.Format("+{0}%", contA);
            costRangeSheet.Range[$"E11"].Value = string.Format(" {0}%", contB);
            return workbook;
        }
        //judge if an image is blank
        private bool IsImageBlank(Image image)
        {
            Bitmap bitmap = new Bitmap(image);
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    Color pixel = bitmap.GetPixel(i, j);
                    if (pixel.R < 240 || pixel.G < 240 || pixel.B < 240)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private Workbook FillDataHeader(Workbook workbook, CraReportDto retObj)
        {
            var date = "'" + DateTime.Now.ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
            var listSheet = workbook.Worksheets.ToList();
            for (int i = 1; i < listSheet.Count; i++)
            {
                listSheet[i].Range["D3"].Value = date;
            }
            return workbook;
        }

        private Workbook DrawSpiderChart(Workbook workbook, CraReportDto retObj)
        {
            var spiderkSheet = workbook.Worksheets[6];
            var sheetDataFirstChart = workbook.Worksheets[14];
            var location = workbook.Worksheets[7].Range["C13"].NumberValue;
            var scope = workbook.Worksheets[8].Range["C18"].NumberValue;
            var economics = workbook.Worksheets[9].Range["C15"].NumberValue;
            var commerical = workbook.Worksheets[10].Range["C15"].NumberValue;
            var inter = workbook.Worksheets[11].Range["C13"].NumberValue;
            var exter = workbook.Worksheets[12].Range["C17"].NumberValue;
            sheetDataFirstChart.Range["U2"].NumberValue = location;
            sheetDataFirstChart.Range["U3"].NumberValue = scope;
            sheetDataFirstChart.Range["U4"].NumberValue = economics;
            sheetDataFirstChart.Range["U5"].NumberValue = commerical;
            sheetDataFirstChart.Range["U6"].NumberValue = inter;
            sheetDataFirstChart.Range["U7"].NumberValue = exter;


            // fill data number
            spiderkSheet.Range["E8"].NumberValue = Double.IsNaN(location)? 0 : Math.Round(location,2);
            spiderkSheet.Range["E12"].NumberValue = Double.IsNaN(scope)? 0 : Math.Round(scope,2);
            spiderkSheet.Range["E16"].NumberValue = Double.IsNaN(economics)? 0 : Math.Round(economics,2);
            spiderkSheet.Range["E20"].NumberValue = Double.IsNaN(commerical)? 0 : Math.Round(commerical,2);
            spiderkSheet.Range["E24"].NumberValue = Double.IsNaN(inter)? 0 : Math.Round(inter,2);
            spiderkSheet.Range["E28"].NumberValue = Double.IsNaN(exter)? 0 : Math.Round(exter,2);
            return workbook;

        }
        /// <summary>
        /// This method is used to draw probability function chart
        /// </summary>
        /// <param name="workbook"></param>
        /// <param name="retObj"></param>
        /// <returns>Workbook</returns>
        private Workbook DrawProbabilityFunctionChart(Workbook workbook, CraReportDto retObj, decimal baseEstimate, decimal totalRiskScore, string estimateClass, Guid revisionId, ProjectRevision revision)
        {
            var probabilitySheet = workbook.Worksheets[3];
            var sheetDataFirstChart = workbook.Worksheets[14];
            var introSheet = workbook.Worksheets[0];
            string projectName = revision.Project.Name;

            // fill data to intro
            introSheet.Range["A15"].Value = "PROJECT " + projectName;
            introSheet.Range["A17"].Value = string.Format("({0})", revision.ProjectStage.Stage);
            probabilitySheet.Range[$"B5"].Value = ": " + projectName;
            // fill data to project infomation
            var baseEst = Math.Round(baseEstimate, 2).ToString() + " M";
            probabilitySheet.Range[$"B7"].Value = ": " + baseEst;
            probabilitySheet.Range[$"E6"].Value = ": " + estimateClass;
            probabilitySheet.Range[$"E7"].Value = ": " + MalayCurr;
            probabilitySheet.Range[$"E8"].Value = ": " + ExchangeRate;
            probabilitySheet.Range[$"E9"].Value = ": " + Math.Round(totalRiskScore, 2).ToString();
            probabilitySheet.Range[$"E5"].Text = ": " + Convert.ToString(revision.Project.Area);
            var projectType = int.Parse(revision.Project.ProjectType);
            probabilitySheet.Range[$"B8"].Value = projectType == 1 ? ": " + ProjectType.Upstream.ToString() : projectType == 2 ? ": " + ProjectType.Downstream.ToString() : ": " + ProjectType.Midstream.ToString();

            var p50Est = Math.Round(retObj.P50Estimate, 3).ToString() + " M";
            var p90Est = Math.Round(retObj.P90Estimate, 3).ToString() + " M";
            var p10Est = Math.Round(retObj.P10Estimate, 3).ToString() + " M";
            var p90EstPercBase = Math.Round(retObj.P90EstimatePercentageOfBase, 2).ToString() + "%";

            probabilitySheet.Range[$"B9"].Value =  ": " + p50Est;
            probabilitySheet.Range[$"B10"].Value = ": " + p90Est;
            probabilitySheet.Range[$"B11"].Value = ": " + p10Est;
            probabilitySheet.Range[$"E11"].Value = ": " + retObj.ContingencyPercentageOfBase.ToString() + "%";

            probabilitySheet.Range[$"B6"].Value = ": ";
            double contA = Math.Round(((retObj.P90Estimate - retObj.P50Estimate) / retObj.P50Estimate) * 100, 0);
            double contB = Math.Round(((retObj.P10Estimate - retObj.P50Estimate) / retObj.P10Estimate) * 100, 0);

            probabilitySheet.Range[$"E10"].Value = ": " + string.Format("+{0}% / {1}%", contA, contB);

            
            //
            sheetDataFirstChart.Range["E2"].NumberValue = retObj.P10Estimate;
            sheetDataFirstChart.Range["F2"].NumberValue = retObj.P10Estimate;
            sheetDataFirstChart.Range["H2"].NumberValue = retObj.ProbabilityDensityP10EstimateY;

            sheetDataFirstChart.Range["E3"].NumberValue = retObj.P50Estimate;
            sheetDataFirstChart.Range["F3"].NumberValue = retObj.P50Estimate;
            sheetDataFirstChart.Range["H3"].NumberValue = retObj.ProbabilityDensityP50EstimateY;

            sheetDataFirstChart.Range["E4"].NumberValue = retObj.P90Estimate;
            sheetDataFirstChart.Range["F4"].NumberValue = retObj.P90Estimate;
            sheetDataFirstChart.Range["H4"].NumberValue = retObj.ProbabilityDensityP90EstimateY;

            sheetDataFirstChart.Range["E5"].NumberValue = retObj.BaseEstimate;
            var serieData = retObj.ProbabilityDensityData.Series;
            var temp = 2;
            foreach (var item in serieData)
            {
                sheetDataFirstChart.Range[$"B{temp}"].NumberValue = item.Value.XValue;
                sheetDataFirstChart.Range[$"C{temp}"].NumberValue = item.Value.YValue;
                temp++;
            }
            Chart firstChart = probabilitySheet.Charts[0];
            ChartSerie probabilitySerie = firstChart.Series["Probability Density Function"];
            probabilitySerie.CategoryLabels = sheetDataFirstChart.Range[$"B2:B{serieData.Count + 1}"];
            probabilitySerie.Values = sheetDataFirstChart.Range[$"C2:C{serieData.Count + 1}"];
            return workbook;
        }

        /// <summary>
        /// This method is used to draw cumulative function chart
        /// </summary>
        /// <param name="workbook"></param>
        /// <param name="retObj"></param>
        /// <returns>Workbook</returns>
        private Workbook DrawCumalativeFunctionChart(Workbook workbook, CraReportDto retObj)
        {
            var cumalativeSheet = workbook.Worksheets[4];
            var sheetDataFirstChart = workbook.Worksheets[14];
            sheetDataFirstChart.Range["N2"].NumberValue = retObj.P10Estimate;
            sheetDataFirstChart.Range["O2"].NumberValue = retObj.P10Estimate;
            sheetDataFirstChart.Range["Q2"].NumberValue = retObj.CumProbabilityData.Series.Where(x => Math.Round(x.Value.XValue) == Math.Round(retObj.P10Estimate)).FirstOrDefault().Value.YValue / 100;


            sheetDataFirstChart.Range["N3"].NumberValue = retObj.P50Estimate;
            sheetDataFirstChart.Range["O3"].NumberValue = retObj.P50Estimate;
            sheetDataFirstChart.Range["Q3"].NumberValue = retObj.CumProbabilityData.Series.Where(x => Math.Round(x.Value.XValue) == Math.Round(retObj.P50Estimate)).FirstOrDefault().Value.YValue / 100; ;

            sheetDataFirstChart.Range["N4"].NumberValue = retObj.P90Estimate;
            sheetDataFirstChart.Range["O4"].NumberValue = retObj.P90Estimate;
            sheetDataFirstChart.Range["Q4"].NumberValue = retObj.CumProbabilityData.Series.Where(x => Math.Round(x.Value.XValue) == Math.Round(retObj.P90Estimate)).FirstOrDefault().Value.YValue / 100; ;

            sheetDataFirstChart.Range["N5"].NumberValue = retObj.BaseEstimate;

            var serieData = retObj.CumProbabilityData.Series;
            var temp = 2;
            foreach (var item in serieData)
            {
                sheetDataFirstChart.Range[$"L{temp}"].NumberValue = item.Value.XValue;
                sheetDataFirstChart.Range[$"K{temp}"].NumberValue = item.Value.YValue / 100;
                temp++;
            }

            Chart firstChart = cumalativeSheet.Charts[0];
            ChartSerie cumalativeSheetSerie = firstChart.Series["Cum. Probability"];
            cumalativeSheetSerie.CategoryLabels = sheetDataFirstChart.Range[$"L2:L{serieData.Count + 1}"];
            cumalativeSheetSerie.Values = sheetDataFirstChart.Range[$"K2:K{serieData.Count + 1}"];

            return workbook;
        }

        /// <summary>
        /// The Method is used to convert list of object into datatable
        /// </summary>
        /// <typeparam name="TDataClass"></typeparam>
        /// <param name="dataList"></param>
        /// <returns>DataTable</returns>
        private DataTable GetDataTableFromObjects<TDataClass>(List<TDataClass> dataList) where TDataClass : class
        {

            Type t = typeof(TDataClass);

            DataTable dt = new DataTable(t.Name);

            foreach (PropertyInfo pi in t.GetProperties())
            {

                dt.Columns.Add(new DataColumn(pi.Name));
            }

            if (dataList != null)
            {
                foreach (TDataClass item in dataList)
                {
                    DataRow dr = dt.NewRow();

                    foreach (DataColumn dc in dt.Columns)
                    {

                        dr[dc.ColumnName] =

                         item.GetType().GetProperty(dc.ColumnName).GetValue(item, null);

                    }
                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }

        /// <summary>
        /// This method is used to get CRAReport object.
        /// </summary>
        /// <param name="baseEstimate"></param>
        /// <param name="totalRiskScore"></param>
        /// <param name="estimateClass"></param>
        /// <param name="curve"></param>
        /// <returns>CraReportDto</returns>
        private async Task<CraReportDto> GetCraData(decimal baseEstimate, decimal totalRiskScore, string estimateClass, string curve)
        {
            var retObj = new CraReportDto();
            retObj.BaseEstimate = (double)baseEstimate;
            var accuracyExpression = _unitOfWork.LookUpCraAccuracyExpressionRepository.Filter(x => !x.IsDeleted && x.Curve == curve
                        && x.EstimateClass == estimateClass).FirstOrDefault().Expression;
            var contingencyExpression = _unitOfWork.LookUpCraContingencyExpressionRepository.Filter(x => !x.IsDeleted && x.Curve == curve
                        && x.EstimateClass == estimateClass).FirstOrDefault().Expression;

            List<ChartSeriesXYDto<double, double>> seriesList = new List<ChartSeriesXYDto<double, double>>();
            #region chart data
            //chart series data/

            var probabilityDisttributionData = new ChartSeriesXYDto<double, double>();
            probabilityDisttributionData.Title = "Probability Density Function";
            var calculated_PosAcc = _mathHelper.EvaluateExpression(accuracyExpression.Replace("Total_Risk_Score", totalRiskScore.ToString()));
            var calculated_Contingency = _mathHelper.EvaluateExpression(contingencyExpression.Replace("Total_Risk_Score", totalRiskScore.ToString()));

            var positive_Accuracy = calculated_PosAcc;

            if (calculated_PosAcc < 0.102)
            {
                positive_Accuracy = _mathHelper.Ceiling(calculated_PosAcc - 0.002, 0.01);
            }
            else if (calculated_PosAcc < 0.205)
            {
                positive_Accuracy = _mathHelper.Ceiling(calculated_PosAcc - 0.005, 0.02);
            }
            else
            {
                positive_Accuracy = _mathHelper.Ceiling(calculated_PosAcc - 0.015, 0.05);
            }

            var contingency = calculated_Contingency;
            if (calculated_Contingency < 0.152)
            {
                contingency = _mathHelper.Ceiling(calculated_Contingency - 0.002, 0.01);
            }
            else if (calculated_Contingency < 0.245)
            {
                contingency = _mathHelper.Ceiling(calculated_Contingency - 0.005, 0.02);
            }
            else
            {
                contingency = _mathHelper.Ceiling(calculated_Contingency - 0.015, 0.05);
            }

            var calculated_NegAcc = positive_Accuracy * 0.6D;
            var negative_Accuracy = calculated_NegAcc;
            if (calculated_NegAcc < 0.102)
            {
                negative_Accuracy = _mathHelper.Ceiling(calculated_NegAcc - 0.002, 0.01);
            }
            else if (calculated_NegAcc < 0.205)
            {
                negative_Accuracy = _mathHelper.Ceiling(calculated_NegAcc - 0.005, 0.02);
            }
            else
            {
                negative_Accuracy = _mathHelper.Ceiling(calculated_NegAcc - 0.015, 0.05);
            }

            var accuracy_LookUp = positive_Accuracy * 100;
            var pdfXValues = await _unitOfWork.LookUpCraPdfXValueRepository.Filter(x => x.PositiveAccurary == accuracy_LookUp).ToListAsync();
            var pdfYValues = await _unitOfWork.LookUpCraPdfYValueRepository.Filter(x => x.PositiveAccurary == accuracy_LookUp).ToListAsync();

            retObj.Contingency = contingency;
            retObj.P50Estimate = (double)baseEstimate * (1.0D + retObj.Contingency);
            retObj.P90Estimate = retObj.P50Estimate * (1.0D + positive_Accuracy);
            retObj.P10Estimate = retObj.P50Estimate * (1.0D - negative_Accuracy);



            retObj.BaseEstimateContingency = contingency * retObj.BaseEstimate;

            retObj.ContingencyPercentageOfBase = retObj.BaseEstimateContingency / retObj.BaseEstimate * 100.0;
            retObj.P10EstimatePercentageOfBase = (retObj.P10Estimate - retObj.P50Estimate) / retObj.P50Estimate * 100.0;
            retObj.P90EstimatePercentageOfBase = (retObj.P90Estimate - retObj.P50Estimate) / retObj.P50Estimate * 100.0;


            for (var i = 2; i <= 513; i++)
            {
                double xValue = double.Parse(pdfXValues.Where(x => x.RowIndex == i - 1).FirstOrDefault().Value) * retObj.P50Estimate / 100.0D;
                double yValue = double.Parse(pdfYValues.Where(x => x.RowIndex == i - 1).FirstOrDefault().Value);
                var ps = new XYValue<double, double> { XValue = xValue, YValue = yValue };

                probabilityDisttributionData.Series.Add(i.ToString(), ps);
            }


            retObj.ProbabilityDensityP50EstimateY = probabilityDisttributionData.Series.Values.Where(x => x.XValue <= (retObj.P50Estimate + 0.05))
                .Select(obj => new { obj, diff = obj.XValue - (retObj.P50Estimate + 0.05) })
                .OrderByDescending(p => p.diff).First().obj.YValue;
            retObj.ProbabilityDensityP90EstimateY = probabilityDisttributionData.Series.Values.Where(x => x.XValue <= (retObj.P90Estimate + 0.05))
                .Select(obj => new { obj, diff = obj.XValue - (retObj.P90Estimate + 0.05) })
                .OrderByDescending(p => p.diff).First().obj.YValue;
            retObj.ProbabilityDensityP10EstimateY = probabilityDisttributionData.Series.Values.Where(x => x.XValue <= (retObj.P10Estimate + 0.05))
                .Select(obj => new { obj, diff = obj.XValue - (retObj.P10Estimate + 0.05) })
                .OrderByDescending(p => p.diff).First().obj.YValue;

            #endregion
            retObj.ProbabilityDensityData = probabilityDisttributionData;


            //var probabilityOfUnderrunList = new string[] {"0%","1%","5%","10%","15%","20%","25%","30%","35%","40%","45%",
            //    "50%","55%","60%","65%","70%","75%","80%","85%","90%","95%","99%","100%" };
            var probabilityOfUnderrunList = new decimal[] {1,5,10,15,20,25,30,35,40,45,50,
                    55,60,65,70,75,80,85,90,95,99 };

            var cumProbabilityData = new ChartSeriesXYDto<double, double>();
            cumProbabilityData.Title = "Cum. Probability";

            List<CraReportCostRangeDto> costRangeTable = new List<CraReportCostRangeDto>();
            var sCurveValues = await _unitOfWork.LookUpCraSCurveValueRepository.Filter(x => x.PositiveAccurary == accuracy_LookUp).ToListAsync();
            for (var i = 0; i < probabilityOfUnderrunList.Length; i++)
            {
                CraReportCostRangeDto costRangeRow = new CraReportCostRangeDto();

                costRangeRow.ProbabilityOfUnderRun = probabilityOfUnderrunList[i];
                costRangeRow.IndicatedFundingAmount = Math.Round(decimal.Parse(sCurveValues.Where(x => x.Percent == (probabilityOfUnderrunList[i] / 100).ToString()).FirstOrDefault().Value) * (decimal)retObj.P50Estimate / 100.0M, 0);
                costRangeRow.EstimatedContingency = Math.Round(costRangeRow.IndicatedFundingAmount - baseEstimate, 0);
                costRangeRow.PercentageOfBaseEstimate = Math.Round(100 * costRangeRow.IndicatedFundingAmount / baseEstimate, 1);

                costRangeTable.Add(costRangeRow);

                var ps = new XYValue<double, double> { XValue = (double)costRangeRow.IndicatedFundingAmount, YValue = (double)costRangeRow.ProbabilityOfUnderRun };

                cumProbabilityData.Series.Add(i.ToString(), ps);
            }

            retObj.CumProbabilityP50EstimateY = cumProbabilityData.Series.Values.Where(x => x.XValue <= (retObj.P50Estimate + 0.05))
                .Select(obj => new { obj, diff = obj.XValue - (retObj.P50Estimate + 0.05) })
                .OrderByDescending(p => p.diff).First().obj.YValue;
            retObj.CumProbabilityP90EstimateY = cumProbabilityData.Series.Values.Where(x => x.XValue <= (retObj.P90Estimate + 0.05))
                .Select(obj => new { obj, diff = obj.XValue - (retObj.P90Estimate + 0.05) })
                .OrderByDescending(p => p.diff).First().obj.YValue;
            retObj.CumProbabilityP10EstimateY = cumProbabilityData.Series.Values.Where(x => x.XValue <= (retObj.P10Estimate + 0.05))
                .Select(obj => new { obj, diff = obj.XValue - (retObj.P10Estimate + 0.05) })
                .OrderByDescending(p => p.diff).First().obj.YValue;


            retObj.CostRangeTable = costRangeTable;
            retObj.CumProbabilityData = cumProbabilityData;

            return retObj;
        }

        /// <summary>
        /// This method is used to get the saved project deterministic values
        /// </summary>
        /// <param name="revisionId"></param>
        /// <returns>IEnumerable<ProjectDeterministicValue></returns>
        private IEnumerable<ProjectDeterministicValue> GetProjectDeterministicVales(Guid revisionId)
        {

            //Get the deterministic revision id
            var deterministicValues = _unitOfWork.ProjectDeterministicValueRepository.Filter(x => x.ProjectRevisionId == revisionId && x.IsDeleted == false, source => source.Include(x => x.DeterministicValue));

            return deterministicValues;
        }

        /// <summary>
        /// This method is used to enter deterministic values
        /// </summary>
        /// <param name="projectDeterministicValues"></param>
        /// <param name="worksheet"></param>
        private void InsertDeterMinisticValuesStructure(IEnumerable<ProjectDeterministicValue> projectDeterministicValues, Workbook workbook, string estimateClass)
        {
            //Entering Location Values
            var locationDetValues = GetProjectDeterMinisticValues(projectDeterministicValues.Where(x => x.DeterministicValue.Section == "Location"));
            double sumLocation = 0;

         
            if (locationDetValues.Any())
            {
                var worksheet = workbook.Worksheets[7];

                var subSection = locationDetValues.Select(x => new { x.Item1 }).ToList();
                var locAll = locationDetValues.Select(x => new { x.Item2, x.Item3, x.Item4 }).ToList();

                var dt1 = GetDataTableFromObjects(subSection);
                var dt2 = GetDataTableFromObjects(locAll);

                worksheet.InsertDataTable(dt1, false, 9, 1);
                worksheet.InsertDataTable(dt2, false, 9, 3);

                var value = Math.Round((locationDetValues.Sum(x => (double)x.Item2 / 4)), 1);
                worksheet.Range[$"C13"].NumberValue = value;

                //get sum of location weighting
                double[] locationScore = new double[] { 6, 4, 14, 3 };
                for (int i = 0; i < locationScore.Length; i++)
                {
                    sumLocation += _mathHelper.FactorValue(double.Parse(worksheet.Range[$"C{9 + i}"].Value), locationScore[i]);
                }


                worksheet.Range["A9:E12"].AutoFitRows();
                worksheet.Range["E9:E12"].IsWrapText = true;

                

            }

            //Entering Scope Values
            var scopeDetValues = GetProjectDeterMinisticValues(projectDeterministicValues.Where(x => x.DeterministicValue.Section == "Scope"));

            double sumScope = 0;
            if (scopeDetValues.Any())
            {
                var worksheet = workbook.Worksheets[8];

                var subSection = scopeDetValues.Select(x => new { x.Item1 }).ToList();
                var scopeAll = scopeDetValues.Select(x => new { x.Item2, x.Item3, x.Item4 }).ToList();

                var dt1 = GetDataTableFromObjects(subSection);
                var dt2 = GetDataTableFromObjects(scopeAll);

                worksheet.InsertDataTable(dt1, false, 9, 1);
                worksheet.InsertDataTable(dt2, false, 9, 3);

                var value = Math.Round((locationDetValues.Sum(x => (double)x.Item2 / 7)), 1);
                worksheet.Range[$"C18"].NumberValue = value;

                //enter scope weighting
                double first = estimateClass == "5A" ? 10 : 18;
                double second = estimateClass == "5A" ? 3 : estimateClass == "5" ? 7 : estimateClass == "4" ? 15 : 24;
                double third = estimateClass == "5A" ? 3 : 8;
                double fourth = estimateClass == "5A" ? 2 : estimateClass == "5" ? 6 : estimateClass == "4" ? 10 : 20;
                double[] scopeScore = new double[] { first, second, third, fourth, 2, 8, 8, 7, 6 };
                for (int i = 0; i < scopeScore.Length; i++)
                {
                    sumScope += _mathHelper.FactorValue(double.Parse(worksheet.Range[$"C{9 + i}"].Value), scopeScore[i]);
                }

                worksheet.Range["A9:E17"].AutoFitRows();
                worksheet.Range["A9:E17"].IsWrapText = true;

            }

            //Entering Economics Values
            var ecoDetValues = GetProjectDeterMinisticValues(projectDeterministicValues.Where(x => x.DeterministicValue.Section == "Economics"));

            double sumEconomic = 0;
            if (ecoDetValues.Any())
            {

                var worksheet = workbook.Worksheets[9];

                var subSection = ecoDetValues.Select(x => new { x.Item1 }).ToList();
                var ecoAll = ecoDetValues.Select(x => new { x.Item2, x.Item3, x.Item4 }).ToList();

                var dt1 = GetDataTableFromObjects(subSection);
                var dt2 = GetDataTableFromObjects(ecoAll);

                worksheet.InsertDataTable(dt1, false, 9, 1);
                worksheet.InsertDataTable(dt2, false, 9, 3);

                var value = Math.Round((locationDetValues.Sum(x => (double)x.Item2 / 5)), 1);
                worksheet.Range[$"C15"].NumberValue = value;

                //enter economic weighting
                double persenOfPrice = estimateClass == "2" ? 5 : 0;
                double[] economisScore = new double[] { 25, 20, 3, persenOfPrice, 5, 5 };
                for (int i = 0; i < economisScore.Length; i++)
                {
                    sumEconomic += _mathHelper.FactorValue(double.Parse(worksheet.Range[$"C{9 + i}"].Value), economisScore[i]);
                }

                worksheet.Range["A9:E14"].AutoFitRows();
                worksheet.Range["A9:E14"].IsWrapText = true;

            }

            //Entering Commercial Values
            var commDetValues = GetProjectDeterMinisticValues(projectDeterministicValues.Where(x => x.DeterministicValue.Section == "Commercial"));
            double sumCommerical = 0;
            if (commDetValues.Any())
            {
                var worksheet = workbook.Worksheets[10];

                var subSection = commDetValues.Select(x => new { x.Item1 }).ToList();
                var commAll = commDetValues.Select(x => new { x.Item2, x.Item3, x.Item4 }).ToList();

                var dt1 = GetDataTableFromObjects(subSection);
                var dt2 = GetDataTableFromObjects(commAll);

                worksheet.InsertDataTable(dt1, false, 9, 1);
                worksheet.InsertDataTable(dt2, false, 9, 3);

                var value = Math.Round((locationDetValues.Sum(x => (double)x.Item2 / 7)), 1); ;
                worksheet.Range[$"C15"].NumberValue = value;
                //enter commerical weighting
                double[] commericalScore = new double[] { 3, 6, 2, 8, 5, 8 };
                for (int i = 0; i < commericalScore.Length; i++)
                {
                    sumCommerical += _mathHelper.FactorValue(double.Parse(worksheet.Range[$"C{9 + i}"].Value), commericalScore[i]);
                }

                worksheet.Range["A9:E14"].AutoFitRows();
                worksheet.Range["A9:E14"].IsWrapText = true;

            }

            //Entering Interfaces and People Values
            var intPeopleDetValues = GetProjectDeterMinisticValues(projectDeterministicValues.Where(x => x.DeterministicValue.Section == "Interfaces & People"));
            double sumInterface = 0;
            if (intPeopleDetValues.Any())
            {
                var worksheet  = workbook.Worksheets[11];

                var subSection = intPeopleDetValues.Select(x => new { x.Item1 }).ToList();
                var intAll = intPeopleDetValues.Select(x => new { x.Item2, x.Item3, x.Item4 }).ToList();

                var dt1 = GetDataTableFromObjects(subSection);
                var dt2 = GetDataTableFromObjects(intAll);

                worksheet.InsertDataTable(dt1, false, 9, 1);
                worksheet.InsertDataTable(dt2, false, 9, 3);


                var value = Math.Round((locationDetValues.Sum(x => (double)x.Item2 / 4)), 1);
                worksheet.Range[$"C13"].NumberValue = value;

                //enter interface weighting
                double[] interfaceScore = new double[] { 1, 8, 3, 10 };
                for (int i = 0; i < interfaceScore.Length; i++)
                {
                    sumInterface += _mathHelper.FactorValue(double.Parse(worksheet.Range[$"C{9 + i}"].Value), interfaceScore[i]);
                }

                worksheet.Range["A9:E12"].AutoFitRows();
                worksheet.Range["A9:E12"].IsWrapText = true;


            }

            //Entering External & Political Values
            var extPolDetValues = GetProjectDeterMinisticValues(projectDeterministicValues.Where(x => x.DeterministicValue.Section == "External & Political"));
            double sumExternal = 0;
            if (extPolDetValues.Any())
            {
                var worksheet  = workbook.Worksheets[12];

                var subSection = extPolDetValues.Select(x => new { x.Item1 }).ToList();
                var extAll = extPolDetValues.Select(x => new { x.Item2, x.Item3, x.Item4 }).ToList();

                var dt1 = GetDataTableFromObjects(subSection);
                var dt2 = GetDataTableFromObjects(extAll);

                worksheet.InsertDataTable(dt1, false, 9, 1);
                worksheet.InsertDataTable(dt2, false, 9, 3);


                var value = Math.Round((locationDetValues.Sum(x => (double)x.Item2 / 4)), 1);
                worksheet.Range[$"C17"].NumberValue = value;

                //enter external weighting
                double[] enternalWeighting = new double[] { 8, 3, 3, 5, 3, 2, 8, 2 };
                for (int i = 0; i < enternalWeighting.Length; i++)
                {
                    sumExternal += _mathHelper.FactorValue(double.Parse(worksheet.Range[$"C{9 + i}"].Value), enternalWeighting[i]);
                }

                worksheet.Range["A9:E16"].AutoFitRows();
                worksheet.Range["D9:D16"].AutoFitRows();
                worksheet.Range["A9:E16"].IsWrapText = true;

            }

            double sumWeighting = sumLocation + sumScope + sumEconomic + sumCommerical + sumInterface + sumExternal;
            //enter location weighting
            workbook.Worksheets[7].Range[$"E13"].Text = Math.Round((sumLocation / sumWeighting) * 100).ToString() + "%";
            //enter scope weighting
            workbook.Worksheets[8].Range[$"E18"].Text = Math.Round((sumScope / sumWeighting) * 100).ToString() + "%";
            //enter economic weighting
            workbook.Worksheets[9].Range[$"E15"].Text = Math.Round((sumEconomic / sumWeighting) * 100).ToString() + "%";
            //enter commerical weighting
            workbook.Worksheets[10].Range[$"E15"].Text = Math.Round((sumCommerical / sumWeighting) * 100).ToString() + "%";
            //enter interface weighting
            workbook.Worksheets[11].Range[$"E13"].Text = Math.Round((sumInterface / sumWeighting) * 100).ToString() + "%";
            //enter external weighting
            workbook.Worksheets[12].Range[$"E17"].Text = Math.Round((sumExternal / sumWeighting) * 100).ToString() + "%";

        }

        /// <summary>
        /// This method is used to create the table like strucuture for project deterministic values
        /// </summary>
        /// <param name="projectDeterministicValues"></param>
        /// <returns>List<Tuple<string, int, string, string>></returns>
        private List<Tuple<string, int, string, string>> GetProjectDeterMinisticValues(IEnumerable<ProjectDeterministicValue> projectDeterministicValues)
        {
            var tupleList = new List<Tuple<string, int, string, string>>();

            foreach (var deterMinisticValue in projectDeterministicValues)
            {
                tupleList.Add(Tuple.Create(deterMinisticValue.DeterministicValue.SubSection, deterMinisticValue.Score, deterMinisticValue.Comments, deterMinisticValue.DeterministicValue.GuideLines));
            }

            return tupleList;
        }

        /// <summary>
        /// This method is used to convert costrange object into table
        /// </summary>
        /// <param name="costRangeTable"></param>
        /// <returns></returns>
        private List<Tuple<string, string, string, string>> GetCostRangeTableObject(List<CraReportCostRangeDto> costRangeTable)
        {
            var tupleList = new List<Tuple<string, string, string, string>>();

            foreach (var cr in costRangeTable)
            {
                tupleList.Add(Tuple.Create(cr.ProbabilityOfUnderRun.ToString() + "%", cr.IndicatedFundingAmount.ToString(), cr.EstimatedContingency.ToString(), cr.PercentageOfBaseEstimate.ToString() + "%"));
            }

            return tupleList;
        }

        /// <summary>
        /// This method is used to draw page number
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="margin"></param>
        private void DrawPageNumber(PdfPageCollection collection, PdfMargins margin, int startNumber, int pageCount)
        {
            var year = DateTime.Now.Year;
            var footerString = string.Format("© {0} PETROLIAM NASIONAL BERHAD ( PETRONAS )", year);
            foreach (PdfPageBase page in collection)
            {
                
                //page.Canvas.SetTransparency(0.5f);
                PdfBrush brush = PdfBrushes.DarkGray;
                //PdfPen pen = new PdfPen(brush, 0.75f);
                PdfTrueTypeFont font1 = new PdfTrueTypeFont(new Font("Arial", 9f, System.Drawing.FontStyle.Bold), true);
                PdfTrueTypeFont font2 = new PdfTrueTypeFont(new Font("Arial", 7f), true);
                PdfStringFormat format = new PdfStringFormat(PdfTextAlignment.Center);
                PdfStringFormat format2 = new PdfStringFormat(PdfTextAlignment.Left);
                format.MeasureTrailingSpaces = true;
                float space = font1.Height * 0.8f;
                float x = margin.Left;
                float width = (page.Canvas.ClientSize.Width / 2)- margin.Bottom - space;
                float y = page.Canvas.ClientSize.Height - margin.Bottom + space;
                //page.Canvas.DrawLine(pen, x, y, x + width, y);
                if (page == collection[0])
                {
                    page.Canvas.DrawString("Internal", font2, brush, x - 30, y - 50, format2);
                    page.Canvas.DrawString(footerString, font1, brush, x + width, y - 15, format);
                    continue;
                };
                String numberLabel
                    = String.Format("{0}", startNumber++);
                page.Canvas.DrawString("Internal", font2, brush, x - 30, y - 30, format2);
                page.Canvas.DrawString(footerString, font1, brush, x + width, y, format);
                page.Canvas.DrawString(numberLabel, font1, brush, x + width, y + 40, format);
                page.Canvas.ColorSpace = PdfColorSpace.GrayScale;

            }
        }
    }
}
