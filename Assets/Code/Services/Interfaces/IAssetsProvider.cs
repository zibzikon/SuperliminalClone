using System.Threading.Tasks;
using UnityEngine;

namespace Code.Services.Interfaces
{
    public interface IAssetsProvider
    {
        T Get<T>(string name) where T : Object;
        Task<T> GetAsync<T>(string name) where T : Object;
    }
}