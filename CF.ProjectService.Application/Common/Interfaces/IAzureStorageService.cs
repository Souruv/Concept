using CF.ProjectService.Application.Features.UserFeatures.Dto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CF.ProjectService.Application.Common.Interfaces
{
    public interface IAzureStorageService
    {
        public Task<MemoryStream> GetFile(string connectionString, string conteiner, string fileName);
    }
}
