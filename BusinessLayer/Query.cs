using Adapter;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{


    public class Query : IQuery
    {
        private readonly IService _service;

        public Query(IService service)
        {
            _service = service;
        }
        public async Task<HGV> test(string id)
        {
            return  await _service.method(id);
        }
    }
}
