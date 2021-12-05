using MediatR;
using Microsoft.AspNetCore.Hosting;
using Spire.Xls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CF.CostBrainService.Application.Features.HUCHookupCost.Queries
{
    public class GetExcelFile : IRequest<MemoryStream>
    {
        public class DownloadHUCTemplateQueryHandler : IRequestHandler<GetExcelFile, MemoryStream>
        {
            IHostingEnvironment _env;
            public DownloadHUCTemplateQueryHandler(IHostingEnvironment env)
            {
                _env = env;
            }
            public async Task<MemoryStream> Handle(GetExcelFile request, CancellationToken cancellationToken)
            {
                Spire.License.LicenseProvider.SetLicenseFileName(_env.WebRootPath + "\\license.elic.xml");

                string filePath = _env.WebRootPath + "\\Templates\\HUCOutput.xlsx";
                var stream = new MemoryStream();
                Workbook workbook = new Workbook();
                workbook.LoadFromFile(filePath);
                workbook.SaveToStream(stream);

                return stream;
            }
        }
    }
}
