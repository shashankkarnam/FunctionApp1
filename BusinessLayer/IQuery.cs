using Adapter;
using System;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IQuery
    {
        Task<HGV> test(string id);
    }
}
