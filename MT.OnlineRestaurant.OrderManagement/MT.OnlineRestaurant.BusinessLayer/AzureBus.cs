using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using MT.OnlineRestaurant.BusinessLayer.interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MT.OnlineRestaurant.BusinessLayer
{
    public class AzureBus :IAzureServiceBus
    {
        private readonly string _serviceBusCnnectionString;
        private readonly string _subscriptionName;
        private readonly string _topicName;
        static ISubscriptionClient  subscriptionClient;
        static string msgQuantity;
        static ITopicClient topicClient;

        public AzureBus(IConfiguration configuration)
        {
            _serviceBusCnnectionString = configuration["AzureServiceBus:ConnectionString"];
            _topicName = configuration["TopicName:TopicNameString"];
            _subscriptionName = configuration["Subscription:subscriptionString"];
        }

        public string AzureBusService()
        {
            subscriptionClient = new SubscriptionClient(_serviceBusCnnectionString, _topicName, _subscriptionName);
            RegisterAndRecieveMessages();
            return msgQuantity;
        }

         static void RegisterAndRecieveMessages()
        {
            var msgHandlerOptions = new MessageHandlerOptions(ExceptionReceivedHandler) { 
            MaxConcurrentCalls=1,
            AutoComplete=false
            };
            
            subscriptionClient.RegisterMessageHandler(ProcessMessageAsync, msgHandlerOptions);
            
        }

        private static async Task ProcessMessageAsync(Message msg, CancellationToken token)
        {
            msgQuantity = Encoding.UTF8.GetString(msg.Body).ToString();
            await subscriptionClient.CompleteAsync(msg.SystemProperties.LockToken);
        }

        static Task ExceptionReceivedHandler(ExceptionReceivedEventArgs exception)
        {
            return Task.CompletedTask;
        }
    }
}
