using Code.Services.Interfaces;
using UnityEngine;

namespace Code.Services
{
    public class JsonDataSerializer : IDataSerializer
    {
        public string Serialize<T>(T obj) 
            => JsonUtility.ToJson(obj);


        public T Deserialize<T>(string token)
            => JsonUtility.FromJson<T>(token);
    }
}