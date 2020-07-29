using Adapter;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{


    public class Query : IQuery
    {
        private readonly IService _service;

        public Query(IService service)
        {
            _service = service;
        }
        public HGV test(string id)
        {
            return _service.method(id).GetAwaiter().GetResult();
        }
    }
}
