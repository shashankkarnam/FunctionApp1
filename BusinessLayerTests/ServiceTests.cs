using Microsoft.VisualStudio.TestTools.UnitTesting;
using Adapter;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using System.Threading.Tasks;
using System.Threading;

namespace Adapter.Tests
{
    [TestClass()]
    public class ServiceTests
    {

        Mock<IDocumentClient> _docClient = null;

        Service service = null;

        public ServiceTests()
        {
            _docClient = new Mock<IDocumentClient>();
            service = new Service(_docClient.Object);
        }
        [TestMethod()]
        public   void methodTest()
        {
           
            var ans= _docClient.Setup(dc => dc.ReadDocumentAsync<HGV>(
                It.IsAny<Uri>(), It.IsAny<RequestOptions>(), It.IsAny<CancellationToken>())).ReturnsAsync(new DocumentResponse<HGV>() { });
           

            Assert.IsTrue(ans != null);
        }
    }
}