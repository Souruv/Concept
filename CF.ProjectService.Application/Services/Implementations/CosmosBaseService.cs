using CF.ProjectService.Application.Services.Interfaces;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CF.ProjectService.Application.Services.Implementations
{
    public abstract class CosmosBaseService<TEntity> : ICosmosBaseService<TEntity> where TEntity : class
    {
     
        private readonly Container _container;

        
        public abstract string ContainerId { get; }

        public CosmosBaseService(CosmosClient cosmosClient,string databasename)
        {
           
            _container = cosmosClient.GetContainer(databasename, ContainerId);
            
        }

        public async Task AddItemAsync(TEntity entity, string partitionKey)
        {
            var dbObject = await GetItemAsync(partitionKey);
            if (dbObject == null)
            {
                await _container.CreateItemAsync<TEntity>(entity, new PartitionKey(partitionKey));
            }
            else
            {
                await _container.ReplaceItemAsync<TEntity>(entity, partitionKey, new PartitionKey(partitionKey));
            }
            
        }

        public async Task DeleteAsync(string id, string partitionKey)
        {
            await _container.DeleteItemAsync<TEntity>(id, new PartitionKey(partitionKey));
        }

     

        public async Task<IEnumerable<TEntity>>  GetAllAsync(string queryString)
        {
           var query = this._container.GetItemQueryIterator<TEntity>(new QueryDefinition(queryString));
            List<TEntity> results = new List<TEntity>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                
                results.AddRange(response.ToList());
            }

            return results;
        }

      

         public async Task<TEntity> GetItemAsync(string id)
        {
            try
            {
                ItemResponse<TEntity> response = await this._container.ReadItemAsync<TEntity>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch(CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            { 
                return null;
            }

        }

     
    }
}
