using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CF.ProjectService.Application.Services.Interfaces
{
    public interface ICosmosBaseService<TEntity>  where TEntity:class 
    {
         string ContainerId { get; }

        Task AddItemAsync(TEntity entity, string partitionKey);

        Task DeleteAsync(string id, string partitionKey);

        Task<IEnumerable<TEntity>>  GetAllAsync(string queryString);

       
        Task<TEntity> GetItemAsync(string id);
        

        
    }
}
