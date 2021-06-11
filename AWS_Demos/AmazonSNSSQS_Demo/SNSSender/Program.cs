using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace AmazonSNSSQS_Demo
{
    class Program
    {
        
        static async Task Main(string[] args)
        {
            Boolean continuar = true;
            
            while (continuar)
            {
                Thread.Sleep(5000);
                await sendSNSMessageAsync();          
            }
        }

        static async Task sendSNSMessageAsync()
        {
            //Send a message to the SNS event topic

            var snsClient = new AmazonSimpleNotificationServiceClient();

            // Creating the topic request and the topic and response  
            var topicRequest = new CreateTopicRequest
            {
                Name = "TestSNSTopic"
            };

            var topicResponse =await snsClient.CreateTopicAsync(topicRequest);

            var subscribeRequest = new SubscribeRequest()
            {
                TopicArn = topicResponse.TopicArn,
                Protocol = "application", // important to chose the protocol as I am sending notification to applications I have chosen application here.  
                Endpoint = ""
            };

            var reqObj = new Dictionary<String,String>();
            reqObj["field1"] = "123";
            reqObj["field2"] = "ABC";

            PublishRequest publishReq = new PublishRequest()
            {
                TargetArn = subscribeRequest.Endpoint,
                MessageStructure = "json",
                Message = JsonConvert.SerializeObject(reqObj)
            };

            PublishResponse response =await snsClient.PublishAsync(publishReq);
            if (response != null && response.MessageId != null)
            {
                Console.WriteLine("Notification Send Successfully")  ;
            }
        }

    }
}
