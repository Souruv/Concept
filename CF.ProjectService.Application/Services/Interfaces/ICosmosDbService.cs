using CF.ProjectService.Application.Features.ProjectFeatures.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CF.ProjectService.Application.Services.Interfaces
{
    public interface ICosmosDbService : ICosmosBaseService<ExcelFieldsDataDto>
    {
        //Task<IEnumerable<ProjectFieldDataDto>> GetItemsAsync(string query);
        //Task<ProjectFieldDataDto> GetItemAsync(string id);
        //Task AddItemAsync(ExcelFieldsDataDto item);
        //Task UpdateItemAsync(string id, ProjectFieldDataDto item);
        //Task DeleteItemAsync(string id);
    }
}
