﻿using Microsoft.Azure.Storage.Auth;
using Microsoft.Azure.Storage.Blob;
using System;
using System.IO;
using System.Threading.Tasks;

namespace TSPServer.Services
{
    public class ImageStore
    {
        CloudBlobClient blobClient;
        string baseUri = "https://tspwebstorage.blob.core.windows.net/";

        public ImageStore()
        {
            var credentials = new StorageCredentials("tspwebstorage", "XnreWP+3EwxWb5NlFzZD6+brXatRkk4ObxqBsQgZEsbColMl1dCOCvckTWyXfI4hIBsySDkGjzN94p4GAGU+6g==");
            blobClient = new CloudBlobClient(new Uri(baseUri), credentials);
        }

        public async Task<string> SaveImage(Stream imageStream)
        {
            var imageId = Guid.NewGuid().ToString();
            var container = blobClient.GetContainerReference("images");
            var blob = container.GetBlockBlobReference(imageId);
            await blob.UploadFromStreamAsync(imageStream);
            return imageId;
        }

        public string UriFor(string imageId)
        {
            var sasPolicy = new SharedAccessBlobPolicy
            {
                Permissions = SharedAccessBlobPermissions.Read,
                SharedAccessStartTime = DateTime.UtcNow.AddDays(-10),
                SharedAccessExpiryTime = DateTime.MaxValue
            };

            var container = blobClient.GetContainerReference("images");
            var blob = container.GetBlockBlobReference(imageId);
            var sas = blob.GetSharedAccessSignature(sasPolicy);
            return $"{baseUri}images/{imageId}{sas}";
        }
    }
}