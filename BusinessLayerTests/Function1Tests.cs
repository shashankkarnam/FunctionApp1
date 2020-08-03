using Microsoft.VisualStudio.TestTools.UnitTesting;
using FunctionApp1;
using System;
using System.Collections.Generic;
using System.Text;
using BusinessLayer;
using Moq;
using Adapter;
using System.Net.Http;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace FunctionApp1.Tests
{
    [TestClass()]
    public class Function1Tests: BusinessLayerTests.FunctionTest
    {

        Mock<IQuery> _service = null;

        Function1 function = null;
        public Function1Tests()
        {
            _service = new Mock<IQuery>();
            function = new Function1(_service.Object);
        }

        [TestMethod()]
        public async Task Request_With_Query()
        {
            
            var query = new Dictionary<String, StringValues>();
            query.TryAdd("id", "2");
            var body = "";
            var logger = Mock.Of<ILogger>();
            HGV abc = new HGV();

            abc.Country = "etsimgn";
            abc.HGVName = "etssd";
            _service.Setup(p => p.test("2")).ReturnsAsync(abc);
            var result = await function.Run(req: HttpRequestSetup(query, body),logger);

            var resultObject = result as OkObjectResult;
            Assert.AreEqual("200", resultObject.StatusCode.ToString());

        }

        public async Task NEg()
        {

            var query = new Dictionary<String, StringValues>();
            query.TryAdd("id", "2");
            var body = "";
            var logger = Mock.Of<ILogger>();
            HGV abc = new HGV();

            abc.Country = "etsimgn";
            abc.HGVName = "etssd";
            //_service.Setup(p => p.test("2")).Returns(abc);
            var result = await function.Run(req: HttpRequestSetup(query, body), logger);

            var resultObject = result as NotFoundObjectResult;
            Assert.AreEqual("404", resultObject.StatusCode.ToString());

        }
    }

}