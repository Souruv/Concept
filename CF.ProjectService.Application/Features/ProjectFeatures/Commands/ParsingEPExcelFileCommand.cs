using CF.ProjectService.Application.Common.Interfaces;
using CF.ProjectService.Application.Entities;
using CF.ProjectService.Application.Features.ProjectFeatures.Dto;
using MediatR;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CF.ProjectService.Application.Features.ProjectFeatures.Commands
{
    public class ParsingEPExcelFileCommand : IRequest<bool>
    {
        public IFormFile File { get; set; }
        public class ParsingEPExcelFileCommandHandler : IRequestHandler<ParsingEPExcelFileCommand, bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            public ParsingEPExcelFileCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<bool> Handle(ParsingEPExcelFileCommand request, CancellationToken cancellationToken)
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (var package = new ExcelPackage(request.File.OpenReadStream()))
                {
                   
                    var sCurveCalcsSheet = package.Workbook.Worksheets[6+1];
                    var endColumn = sCurveCalcsSheet.Dimension.End.Column;
                    int endRow = 26;
                    
                    //ICollection<SCurveCalcs> sheetData = new List<SCurveCalcs>();
                    for (int i = 3; i <= endRow; i++)
                    {
                        for (int j = 2; j <= endColumn; j++)
                        {
                            var item = new LookUpCraSCurveValue();
                            item.Percent = sCurveCalcsSheet.Cells[i, 1].Value?.ToString();
                            item.RowIndex = i - 2;
                            if (sCurveCalcsSheet.Cells[2, j].Value?.ToString() == null) break;
                            item.PositiveAccurary = (int)decimal.Parse(sCurveCalcsSheet.Cells[2, j].Value?.ToString());
                            item.Value = sCurveCalcsSheet.Cells[i, j].Value?.ToString();
                            _unitOfWork.LookUpCraSCurveValueRepository.Insert(item);
                        }
                        
                    }
                    await _unitOfWork.CommitAsync();
                    var PDFXSheet = package.Workbook.Worksheets[7 + 1];
                    var endColumnX = PDFXSheet.Dimension.End.Column;
                    var endRowX = 514;
                    for (int i = 3; i <= endRowX; i++)
                    {
                        for (int j = 1; j <= endColumnX; j++)
                        {
                            var item = new LookUpCraPdfXValue();
                            item.RowIndex = i - 2;
                            item.PositiveAccurary = (int)decimal.Parse(PDFXSheet.Cells[2, j].Value?.ToString());
                            item.Value = PDFXSheet.Cells[i, j].Value?.ToString();
                            _unitOfWork.LookUpCraPdfXValueRepository.Insert(item);
                        }

                    }
                    await _unitOfWork.CommitAsync();
                    var PDFYSheet = package.Workbook.Worksheets[8 + 1];
                    var endColumnY = PDFYSheet.Dimension.End.Column;
                    var endRowY = 514;
                    for (int i = 3; i <= endRowY; i++)
                    {
                        for (int j = 1; j <= endColumnY; j++)
                        {
                            var item = new LookUpCraPdfYValue();
                            item.RowIndex = i - 2;
                            item.PositiveAccurary = (int)decimal.Parse(PDFYSheet.Cells[2, j].Value?.ToString());
                            //if (decimal.TryParse(PDFYSheet.Cells[i, j].Value?.ToString(), out decimal value))
                            //{
                            //    item.Value = value;
                            //}
                            //else
                            //{
                            //    item.Value = 0;
                            //};
                            item.Value = PDFYSheet.Cells[i, j].Value?.ToString();
                            _unitOfWork.LookUpCraPdfYValueRepository.Insert(item);
                        }
                    }
                    await _unitOfWork.CommitAsync();

                }
                return true;
            }
            
        }
    }
}
