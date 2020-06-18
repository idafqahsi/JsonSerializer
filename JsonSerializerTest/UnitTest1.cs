using Microsoft.VisualStudio.TestTools.UnitTesting;
using JsonSerializerProject;

namespace JsonSerializer
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ComparingTwoEqualJsons()
        {

            Configuration config = new Configuration(2, "www.training.com", new[] { "192.168.1.8", "192.168.1.2" });


            string serializedJson = Serializer.serializeToJson(config);
            string expectedJson = "{\"Version\":2,\"DomainName\":\"www.training.com\",\"IpAddresses\":[\"192.168.1.8\",\"192.168.1.2\"]}";
            Assert.AreEqual(expectedJson, serializedJson);

        }
        [TestMethod]
        public void ComparingUnequalJsons()
        {

            Configuration config = new Configuration(3, "www.google.com", new[] { "192.168.1.8", "192.168.1.2" });


            string serializedJson = Serializer.serializeToJson(config);
            string expectedJson = "{\"Version\":2,\"DomainName\":\"www.training.com\",\"IpAddresses\":[\"192.168.1.8\",\"192.168.1.2\"]}";
            Assert.AreEqual(expectedJson, serializedJson);

        }
     
    }
}
