using CF.ProjectService.Application.Features.ProjectFeatures.Dto;
using CF.ProjectService.Application.Services.Interfaces;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CF.ProjectService.Application.Services.Implementations
{
    public class CosmosDbService : CosmosBaseService<ExcelFieldsDataDto>,ICosmosDbService
    {

         private readonly Container _container;

        
        

        public override string ContainerId =>  "Summary";

        public CosmosDbService(CosmosClient cosmosClient,string databasename) : base(cosmosClient,databasename)
        {
           
            _container = cosmosClient.GetContainer(databasename, ContainerId);
            
        }
         
        //private Container _container;
        //public CosmosDbService(CosmosClient client,string databasename)
        //{
        //   _container = client.GetContainer(databasename,"Field");
        //}
        //public async Task AddItemAsync(ExcelFieldsDataDto item)
        //{
        //    await this._container.CreateItemAsync<ExcelFieldsDataDto>(item,new PartitionKey(item.Id.ToString()));
        //}

        //public Task DeleteItemAsync(string id)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<ProjectFieldDataDto> GetItemAsync(string id)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<IEnumerable<ProjectFieldDataDto>> GetItemsAsync(string query)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task UpdateItemAsync(string id, ProjectFieldDataDto item)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
