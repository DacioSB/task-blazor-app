using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Components.Forms;

namespace CompleteProject.Services;

public class AzurePhotoService
{
    private readonly string _connectionString;
    private readonly string _containerName;

    public AzurePhotoService(IConfiguration configuration)
    {
        _connectionString = Environment.GetEnvironmentVariable("AZURE_STORAGE_CONNECTION_STRING") 
            ?? configuration["AzureBlob:ConnectionString"] 
            ?? throw new ArgumentNullException("Azure Storage Connection String not found");
            
        _containerName = Environment.GetEnvironmentVariable("AZURE_STORAGE_CONTAINER_NAME")
            ?? configuration["AzureBlob:ContainerName"]
            ?? throw new ArgumentNullException("Container Name not found");
    }
    
    public async Task<string> UploadPhotoAsync(IBrowserFile file)
    {
        if (file == null || file.Size == 0)
        {
            throw new ArgumentException("File cannot be null or empty", nameof(file));
        }

        var blobServiceClient = new BlobServiceClient(_connectionString);
        var containerClient = blobServiceClient.GetBlobContainerClient(_containerName);
        await containerClient.CreateIfNotExistsAsync();

        var filename = $"{Guid.NewGuid()}_{file.Name}";
        var blobClient = containerClient.GetBlobClient(filename);
        var contentType = file.ContentType ?? "application/octet-stream";
        var blobHttpHeaders = new Azure.Storage.Blobs.Models.BlobHttpHeaders
        {
            ContentType = contentType
        };
        using (var stream = file.OpenReadStream(maxAllowedSize: 10 * 1024 * 1024)) // Limit to 10 MB
        {
            await blobClient.UploadAsync(stream, new BlobUploadOptions 
            { 
                HttpHeaders = blobHttpHeaders,
                Conditions = null
            });
        }

        return blobClient.Uri.ToString();
    }
    public async Task<string> GetPhotoUrlAsync(string fileName)
    {
        if (string.IsNullOrEmpty(fileName))
        {
            throw new ArgumentException("File name cannot be null or empty", nameof(fileName));
        }

        var blobServiceClient = new BlobServiceClient(_connectionString);
        var containerClient = blobServiceClient.GetBlobContainerClient(_containerName);
        var blobClient = containerClient.GetBlobClient(fileName);

        if (await blobClient.ExistsAsync())
        {
            return blobClient.Uri.ToString();
        }
        
        throw new FileNotFoundException("File not found in Azure Blob Storage", fileName);
    }
}