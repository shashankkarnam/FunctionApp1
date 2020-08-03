using Adapter;
using Castle.Core.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Tests
{
    [TestClass()]
    public class QueryTests
    {

          Mock<IService> _service = null;

        Query query = null;

        public QueryTests()
        {
            _service = new Mock<IService>();
            query = new Query(_service.Object);
        }

        [TestMethod()]
        public async void testTest()
        {
            HGV abc = new HGV();
          
            abc.Country = "etsimgn";
            abc.HGVName = "etssd";    
            _service.Setup(p => p.method(It.IsAny<string>())).ReturnsAsync(abc);
            HGV res =await  query.test("2");
            Assert.AreEqual(abc,res);
        }
        [TestMethod()]
        public async void testTest1()
        {
            HGV abc = new HGV();

            abc.Country = "etsimgn";
            abc.HGVName = "etssd";
            _service.Setup(p => p.method("2")).ReturnsAsync(abc);
            HGV res =await  query.test("2");
            abc.Country = "s";
            Assert.AreNotEqual(null, abc);
        }
    }
}