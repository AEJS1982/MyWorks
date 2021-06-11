using Amazon;
using Amazon.SQS;
using Amazon.SQS.Model;
using System;
using System.Threading;

namespace SNSReceiver
{
    class Program
    {
        private static string myQueueUrl;

        static async System.Threading.Tasks.Task Main(string[] args)
        {
            Boolean continuar = true;

            //Subscribe to SQS, which is being fed by the SNS topic
            myQueueUrl = "myTestQueue";
            IAmazonSQS sqs = new AmazonSQSClient(RegionEndpoint.EUCentral1);

            //Confirming the queue exists
            ListQueuesRequest listQueuesRequest = new ListQueuesRequest();
            ListQueuesResponse listQueuesResponse =await sqs.ListQueuesAsync(listQueuesRequest);

            while (continuar) {
                ReceiveMessageRequest receiveMessageRequest = new ReceiveMessageRequest();
                receiveMessageRequest.QueueUrl = myQueueUrl;
                ReceiveMessageResponse receiveMessageResponse =await sqs.ReceiveMessageAsync(receiveMessageRequest);
                

                Console.WriteLine("Printing received message.\n");
                foreach (Message message in receiveMessageResponse.Messages)
                {
                    //Print the message
                    Console.WriteLine("  Message");
                    Console.WriteLine("    MessageId: {0}", message.MessageId);
                    Console.WriteLine("    ReceiptHandle: {0}", message.ReceiptHandle);
                    Console.WriteLine("    MD5OfBody: {0}", message.MD5OfBody);
                    Console.WriteLine("    Body: {0}", message.Body);

                    var messageRecieptHandle = message.ReceiptHandle;

                    //Deleting each message
                    Console.WriteLine("Deleting the message.\n");
                    DeleteMessageRequest deleteRequest = new DeleteMessageRequest();
                    deleteRequest.QueueUrl = myQueueUrl;
                    deleteRequest.ReceiptHandle = messageRecieptHandle;
                    await sqs.DeleteMessageAsync(deleteRequest);
                }

                Thread.Sleep(5000);

            }
        }
    }
}
