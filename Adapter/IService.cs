using System;
using System.Threading.Tasks;

namespace Adapter
{
    public interface IService
    {
         Task<HGV> method(string id);
    }
}
