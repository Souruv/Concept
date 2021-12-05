using CF.ProjectService.Application.Features.ProjectFeatures.Dto;
using CF.ProjectService.Application.Services.Interfaces;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ProjectService.Application.Services.Implementations
{
    public class CosmosWellService : CosmosBaseService<ExcelCFPlusDto>, ICosmosWellService
    {
          private readonly Container _container;

        
        

        public override string ContainerId =>  "Detail";

        public CosmosWellService(CosmosClient cosmosClient,string databasename) : base(cosmosClient,databasename)
        {
           
            _container = cosmosClient.GetContainer(databasename, ContainerId);
            
        }
    }
}
