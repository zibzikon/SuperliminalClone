using System.Threading.Tasks;
using Code.Extensions;
using Code.Infrastructure.Interfaces;
using UnityEngine;

namespace Code.Infrastructure
{
    public class ResourcesBasedAssetsProvider : IAssetsProvider
    {
        public T Get<T>(string name) where T : Object
            => Resources.Load<T>(name);

        public async Task<T> GetAsync<T>(string name) where T : Object
        {
            var request = Resources.LoadAsync<T>(name);
            
            await request;

            return request.asset as T;
        }
    }
}