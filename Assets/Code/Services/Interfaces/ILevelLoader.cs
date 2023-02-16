using System.Threading.Tasks;
using Code.Data;
using UnityEngine;

namespace Code.Services.Interfaces
{
    public interface ILevelLoader
    {
        public AsyncOperation LevelLoadingAsyncOperation { get; }
        Task LoadAsync(LevelData levelData);
    }
} 