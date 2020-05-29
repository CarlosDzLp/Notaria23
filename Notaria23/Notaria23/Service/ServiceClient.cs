using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Notaria23.Helpers;

namespace Notaria23.Service
{
    public class ServiceClient : IServiceClient
    {
        public Task<T> Delete<T>(string url)
        {
            throw new NotImplementedException();
        }

        public Task<T> Get<T>(string url)
        {
            throw new NotImplementedException();
        }

        public Task<T> Post<T, K>(K deserialice, string url)
        {
            throw new NotImplementedException();
        }

        public Task<T> Put<T, K>(K deserialice, string url)
        {
            throw new NotImplementedException();
        }
    }
}
