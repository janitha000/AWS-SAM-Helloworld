using Amazon.Lambda.Core;
using Amazon.SimpleSystemsManagement;
using Amazon.SimpleSystemsManagement.Model;
using Amazon.SQS;
using Amazon.SQS.Model;
using Microsoft.Extensions.Options;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace AWSHelloWorldLayer;

public class SQSHelper : ISQSHelper
{
    private readonly IAmazonSQS _sqs;
    public SQSHelper(IAmazonSQS sqs)
    {
        _sqs= sqs;
    }
    public async Task<bool> SendMessageAsync(string message)
    {
        try
        {
            //var sendRequest = new SendMessageRequest(_settings.AWSSQS.QueueUrl, message);
            var sendRequest = new SendMessageRequest("https://sqs.ap-southeast-1.amazonaws.com/628640267234/HelloWorldQueue", message);
            // Post message or payload to queue  
            var sendResult = await _sqs.SendMessageAsync(sendRequest);

            return sendResult.HttpStatusCode == System.Net.HttpStatusCode.OK;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
