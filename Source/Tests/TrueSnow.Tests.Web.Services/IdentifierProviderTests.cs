//namespace TrueSnow.Tests.Web.Services
//{
//    using NUnit.Framework;
//    using TrueSnow.Services.Web;
//    using TrueSnow.Services.Web.Contracts;

//    [TestFixture]
//    public class IdentifierProviderTests
//    {
//        [Test]
//        public void EncodingAndDecodingDoesntChangeTheId()
//        {
//            const int Id = 1337;
//            IIdentifierProvider provider = new IdentifierProvider();
//            var encoded = provider.EncodeId(Id);
//            var actual = provider.DecodeId(encoded);
//            Assert.AreEqual(Id, actual);
//        }
//    }
//}
