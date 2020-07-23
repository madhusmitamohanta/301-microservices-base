using Microsoft.Azure.ServiceBus;
using MT.OnlineRestaurant.DataLayer.EntityFrameWorkModel;
using MT.OnlineRestaurant.DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MT.OnlineRestaurant.BusinessLayer
{
    public class AzureServiceBus : IAzureServiceBus
    {

        private readonly string _serviceBusCnnectionString;
        private readonly string _serviceBusCnnectionString_Second;
        private readonly string _subscriptionName_Recieve;
        private readonly string _subscriptionName_Send;
        private readonly string _topicName_Recieve;
        private readonly string _topicName_Send;
        static ISubscriptionClient subscriptionClient;
        static string msgQuantity;
        static ITopicClient topicClient;

        static TblMenu stockInfo;
        static string ItemValue;
        static string orgnlPrice;

        static List<string> msgList = new List<string>();
        static string callbackmessagetosend = string.Empty;

        private static ISearchRepository _searchRepository;

        public AzureServiceBus(Microsoft.Extensions.Configuration.IConfiguration configuration, ISearchRepository searchRepository)
        {
            _searchRepository = searchRepository;
            _serviceBusCnnectionString_Second = configuration["AzureServiceBus:ConnectionString_Second"];
            _serviceBusCnnectionString = configuration["AzureServiceBus:ConnectionString_First"];
            _topicName_Recieve = configuration["TopicName:TopicNameString_Recieve"];
            _topicName_Send = configuration["TopicName:TopicNameString_Send"];
            _subscriptionName_Recieve = configuration["Subscription:subscriptionString_Recieve"];
            _subscriptionName_Send = configuration["Subscription:subscriptionString_Send"];
        }



        public string AzureBusService()
        {
            subscriptionClient = new SubscriptionClient(_serviceBusCnnectionString, _topicName_Recieve, _subscriptionName_Send);
            topicClient = new TopicClient(_serviceBusCnnectionString_Second, _topicName_Send);
            RegisterAndRecieveMessages();
            return msgQuantity;
        }

        static void RegisterAndRecieveMessages()
        {
            var msgHandlerOptions = new MessageHandlerOptions(ExceptionReceivedHandler)
            {
                MaxConcurrentCalls = 1,
                AutoComplete = false
            };

            subscriptionClient.RegisterMessageHandler(ProcessMessageAsync, msgHandlerOptions);

        }

        private static async Task ProcessMessageAsync(Message msg, CancellationToken token)
        {
            string data = Encoding.UTF8.GetString(msg.Body);
            msgList.Add(data);

            await subscriptionClient.CompleteAsync(msg.SystemProperties.LockToken);

            if (msgList.Count == 4)
            {
                stockInfo = _searchRepository.ItemInStock(int.Parse(msgList[0]),int.Parse(msgList[1]));
               
                if (stockInfo.quantity >= Int16.Parse(msgList[3]))
                {
                    ItemValue = "ItemInStock";
                }
                else if(stockInfo.quantity < Int16.Parse(msgList[3]))
                {
                    ItemValue = "ItemOutOfStock";
                }
                msg = new Message(Encoding.UTF8.GetBytes(ItemValue));
                await topicClient.SendAsync(msg);
                msgList = new List<string>();
            }
        }


        static Task ExceptionReceivedHandler(ExceptionReceivedEventArgs exception)
        {
            return Task.CompletedTask;
        }
    }
}
