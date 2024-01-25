using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Mvc;

namespace AwsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SimpleStorageController : ControllerBase
    {
        IAmazonS3 _S3Client;

        public SimpleStorageController(IAmazonS3 s3Client)
        {
            _S3Client = s3Client;
        }


        [HttpPost]
        public async Task<PutBucketResponse> CreateBucket(string bucketName)
        {
            try
            {

                //AmazonS3Config config = new AmazonS3Config
                //{
                //    ServiceURL = "http://127.0.0.1:4566",
                //    UseHttp = true,
                //    ForcePathStyle = true,
                //    AuthenticationRegion = "us-east-1",
                //};
                //AWSCredentials creds = new AnonymousAWSCredentials();

               //AmazonS3Client s3client = new AmazonS3Client(creds, config);

                var request = new PutBucketRequest
                {
                    BucketName = bucketName,
                };

                var result = await _S3Client.PutBucketAsync(request);
                return result;
            }
            catch (AmazonS3Exception ex)
            {
                Console.WriteLine($"Error creating bucket: '{ex.Message}'");
                return null;
            }

        }


    }
}
