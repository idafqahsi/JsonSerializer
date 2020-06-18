using Microsoft.VisualStudio.TestTools.UnitTesting;
using JsonSerializerProject;

namespace JsonSerializer
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            Configuration config = new Configuration(1, "Palestine", new[] {"123","456" });
            string json = Serializer.Analyse(config);
            string json2 = "{\"Version\":2,\"DomainName\":\"www.training.com\",\"IpAddresses\":[\"192.168.1.8\",\"192.168.1.2\"]}";
            Assert.AreEqual(json, json2);

        }
    }
}
