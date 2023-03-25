using Amazon;
using Amazon.KeyManagementService;
using Amazon.KeyManagementService.Model;
using Amazon.S3.Encryption;
using Amazon.S3.Model;

var kmsKeyId = "";
var keyId = "";
var keySecret = "";
var bucketName = "rpadredemo";
var objectKey = "obj-01";

using (var kmsClient = new AmazonKeyManagementServiceClient(keyId, keySecret, RegionEndpoint.USEast1))
{
    var response = await kmsClient.CreateKeyAsync(new CreateKeyRequest());
    kmsKeyId = response.KeyMetadata.KeyId;

    var keyMetadta = response.KeyMetadata;
    var kmsEncryptionMaterials = new EncryptionMaterials(kmsKeyId);

    var config = new AmazonS3CryptoConfiguration()
    {
        RegionEndpoint = RegionEndpoint.USEast1
    };

    using (var s3Client = new AmazonS3EncryptionClient(keyId, keySecret, config, kmsEncryptionMaterials))
    {
        var putRequest = new PutObjectRequest
        {
            BucketName = bucketName,
            Key = objectKey,
            ContentBody = "object content for client side encryption demo"
        };

        await s3Client.PutObjectAsync(putRequest);
    }
}
