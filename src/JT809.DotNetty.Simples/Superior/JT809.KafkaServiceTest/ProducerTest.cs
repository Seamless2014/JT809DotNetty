using System;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using JT809.Protocol.Enums;
using JT809.Protocol.Extensions;
using Google.Protobuf;

namespace JT809.KafkaServiceTest
{
    public class ProducerTest: TestProducerBase
    {
        [Fact]
        public void Test1()
        {
            ProducerTestService producerTestService = ServiceProvider.GetRequiredService<ProducerTestService>();

            producerTestService.GpsProducer.ProduceAsync(JT809SubBusinessType.ʵʱ�ϴ�������λ��Ϣ.ToValueString(), "��A23456_2",
                new GrpcProtos.JT809GpsPosition
                {
                    Vno = "��A23456",
                    VColor = 2,
                    GpsTime = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000,
                    FromChannel = "smallchi"
                }.ToByteArray());
        }

        [Fact]
        public void Test2()
        {
            ProducerTestService producerTestService = ServiceProvider.GetRequiredService<ProducerTestService>();
            producerTestService.SameProducer.ProduceAsync(JT809SubBusinessType.None.ToValueString(), "��A23457_2", new byte[] { 0x01, 0x02, 0x03 });
        }
    }
}
