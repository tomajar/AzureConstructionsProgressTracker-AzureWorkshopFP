using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Configuration;

namespace AzureConstructionsProgressTracker.Features.ProgressTracking
{
    public class FilesStorageService
    {
        private const string ContainerName = "constructionprogressfiles";
        
        public async Task<string> UploadFile(string fileName, HttpPostedFileBase file)
        {
            // TODO: 
            // https://azure.microsoft.com/en-us/documentation/articles/storage-dotnet-how-to-use-blobs/#programmatically-access-blob-storage
            // - Add proper nuget
            // - Connect to storage
            // - create container
            // - upload blob
            // - return URL
            //  throw new NotImplementedException();

            // Retrieve storage account from connection string.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
             ConfigurationManager.AppSettings["StorageConnectionString"]);

            // Retrieve storage account from connection string.
           

            // Create the blob client.
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Retrieve reference to a previously created container.
            CloudBlobContainer container = blobClient.GetContainerReference("acp");

            // Retrieve reference to a blob named "myblob".
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(fileName);
            await blockBlob.UploadFromStreamAsync(file.InputStream);

            return blockBlob.Uri.ToString();
        }
    }
}