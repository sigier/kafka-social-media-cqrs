﻿using System.Text.Json;
using Confluent.Kafka;
using CQRS.Core.Events;
using CQRS.Core.Producers;
using Microsoft.Extensions.Options;

namespace Post.Cmd.Infrastructure.Producers
{
    public class EventProducer: IEventProducer
    {
        private  readonly ProducerConfig _config;

        public EventProducer(IOptions<ProducerConfig> config)
        {
            _config = config.Value;

        }
        public async Task ProduceAsync<T>(string topic, T @event) where T : BaseEvent
        {
            using IProducer<string, string> producer = new ProducerBuilder<string, string>(_config)
                .SetKeySerializer(Serializers.Utf8)
                .SetValueSerializer(Serializers.Utf8)
                .Build();

            Message<string, string> eventMessage = new Message<string, string>
            {
                Key = Guid.NewGuid().ToString(),
                Value = JsonSerializer.Serialize(@event, @event.GetType())
            };

            DeliveryResult<string, string> deliveryResult = await producer.ProduceAsync(topic, eventMessage);

            if (deliveryResult.Status == PersistenceStatus.NotPersisted)
            {
                throw new Exception($"{@event.GetType().Name} can not be produced!");
            }


        }
    }
}
