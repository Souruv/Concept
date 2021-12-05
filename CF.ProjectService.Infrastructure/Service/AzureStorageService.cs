using Azure.Storage.Blobs;
using CF.ProjectService.Application.Common.Interfaces;
using CF.ProjectService.Application.Features.UserFeatures.Dto;
using Microsoft.Extensions.Configuration;
using Microsoft.Graph;
//using Microsoft.Graph.Auth;
using Microsoft.Identity.Client;
//using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Conceptor.Infrastructure.Service
{
    public class AzureStorageService : IAzureStorageService
    {

       public async Task<MemoryStream> GetFile(string connectionString,string conteiner,string fileName)
        {
            // Create a BlobServiceClient object which will be used to create a container client
            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);


            // Create the container and return a container client object
            BlobContainerClient containerClient =  blobServiceClient.GetBlobContainerClient(conteiner);

            BlobClient blobClient = containerClient.GetBlobClient(fileName);

            var ms = new MemoryStream();
            await blobClient.DownloadToAsync(ms);

            return ms;
            //byte[] content = ms.ToArray();
            //return content;
        }
       
    }


}
